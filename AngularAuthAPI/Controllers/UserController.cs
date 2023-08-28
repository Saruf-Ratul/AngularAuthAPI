using AngularAuthAPI.Context;
using AngularAuthAPI.Helpers;
using AngularAuthAPI.Models;
using AngularAuthAPI.Models.DTO_s;
using AngularAuthAPI.Models.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace AngularAuthAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly ISendGridClient _sendGridClient;
        const string SessionName = "emailToken";
        const string SessionAge = "emailTokenExpiry";
        public UserController(AppDbContext context, IConfiguration configuration, IMapper mapper, ISendGridClient sendGridClient)
        {
            _context = context;
            _configuration = configuration;
            _mapper = mapper;
            _sendGridClient = sendGridClient;
        }

        [HttpPost("authenticate")]
        public async Task<ActionResult<UserDto>> Authenticate([FromBody] LoginDto loginObj)
        {
            if (loginObj == null)
                return BadRequest(new { Message = "Form is empty" });

            var user = await _context.Users.FirstOrDefaultAsync(x => x.Username == loginObj.Username);

            if (user == null)
                return NotFound(new { message = "User Not Found!" });

            if (!PasswordHasher.VerifyPassword(loginObj.Password, user.Password))
                return BadRequest(new { message = "Log in failed" });

            user.Token = CreateToken(user);
            user.RefreshToken = CreateRefreshToken();
            user.RefreshTokenExpiryTime = DateTime.Now.AddDays(7);
            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            UserDto userDto = _mapper.Map<UserDto>(user);



            return Ok(new
            {
                AccessToken = user.Token,
                RefreshToken = user.RefreshToken
            });
        }

        [HttpPost("register")]
        public async Task<IActionResult> AddUser([FromBody] RegisterDto registerDto)
        {
            try
            {
                var userObj = _mapper.Map<User>(registerDto);
                // check email
                if (await checkEmailExistAsync(userObj.Email))
                    return BadRequest(new { Message = "Email Already Exist" });

                //check username
                if (await checkUsernameExistAsync(userObj.Username))
                    return BadRequest(new { Message = "Username Already Exist" });

                var passMessage = CheckPasswordStrength(userObj.Password);
                if (!string.IsNullOrEmpty(passMessage))
                    return BadRequest(new { Message = passMessage.ToString() });

                userObj.Password = PasswordHasher.HashPassword(userObj.Password);
                userObj.Role = "User";
                userObj.Token = "";
                await _context.AddAsync(userObj);
                await _context.SaveChangesAsync();
                return Ok(new
                {
                    Status = 200,
                    Message = "User Added!"
                });
            }
            catch (Exception)
            {

                throw;
            }
        }

        [Authorize(Roles = "User")]
        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            var users = _mapper.Map<List<User>, List<UserDto>>(await _context.Users.ToListAsync());
            return Ok(users);
        }


        [HttpPost]
        [Route("refresh")]
        public async Task<IActionResult> Refresh(TokenApiDto TokenApiDto)
        {
            if (TokenApiDto is null)
                return BadRequest("Invalid client request");
            string accessToken = TokenApiDto.AccessToken;
            string refreshToken = TokenApiDto.RefreshToken;
            var principal = GetPrincipalFromExpiredToken(accessToken);
            var username = principal.Identity.Name; //this is mapped to the Name claim by default
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
            if (user is null || user.RefreshToken != refreshToken || user.RefreshTokenExpiryTime <= DateTime.Now)
                return BadRequest("Invalid client request");
            var newAccessToken = CreateToken(user);
            var newRefreshToken = CreateRefreshToken();
            user.RefreshToken = newRefreshToken;
            await _context.SaveChangesAsync();
            return Ok(new TokenApiDto()
            {
                AccessToken = newAccessToken,
                RefreshToken = newRefreshToken
            });
        }

        [HttpPost]
        [Route("send-reset-email/{email}")]
        public async Task<IActionResult> SendEmail(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(a => a.Email == email);
            if (user is null)
                return NotFound(new
                {
                    StatusCode = 404,
                    Message = "Email Doesn't Exist"
                });
            var tokenBytes = RandomNumberGenerator.GetBytes(64);
            var emailToken = Convert.ToBase64String(tokenBytes);
            user.ResetPasswordToken = emailToken;
            user.ResetPasswordExpiry = DateTime.Now.AddMinutes(5);
            string from = _configuration["EmailSettings:From"];
            string fromName = "Let's Program";
            var msg = new SendGridMessage()
            {
                From = new EmailAddress(from, fromName),
                Subject = "Reset Password!",
                HtmlContent = EmailBody.EmailStringBody(email,emailToken)
            };
            msg.AddTo(email);
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            var response = await _sendGridClient.SendEmailAsync(msg);
            string message = response.IsSuccessStatusCode ? "Email Send" : "Email Not Sent";
            return Ok(new
            {
                StatusCode = 200,
                Message = message
            });
        }

        [HttpPost]
        [Route("reset-email")]
        public async Task<IActionResult> ResetPassword(ResetPasswordDto resetPasswordDto)
        {
            var user = await _context.Users.AsNoTracking().FirstOrDefaultAsync(a => resetPasswordDto.Email == a.Email);
            if (user is null)
                return NotFound(new
                {
                    StatusCode = 404,
                    Message = "No user found with this email!"
                });
            var tokenCode = user.ResetPasswordToken;
            DateTime emailTokenExpiry = user.ResetPasswordExpiry;
            var first = tokenCode != resetPasswordDto.EmailToken;
            var second = emailTokenExpiry < DateTime.Now;
            if ( first || second)
                return NotFound(new
                {
                    StatusCode = 400,
                    Message = "Invalid reset link!"
                });
            user.Password = PasswordHasher.HashPassword(resetPasswordDto.NewPassword);
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(new
            {
                StatusCode = 200,
                Message = "Password Reset Successfully!"
            });
        }

        private string CreateToken(User user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration.GetSection("AppSettings:SecretKey").Value);
            var identity = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Role, user.Role),
                    new Claim(ClaimTypes.Email,user.Email),
                    new Claim(ClaimTypes.Name, $"{user.Username}")
                });
            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = identity,
                Expires = DateTime.Now.AddSeconds(10),
                SigningCredentials = credentials
            };

            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            return jwtTokenHandler.WriteToken(token);
        }

        private string CreateRefreshToken()
        {
            var tokenBytes = RandomNumberGenerator.GetBytes(64);
            var refreshtoken = Convert.ToBase64String(tokenBytes);

            var tokenIsInUser = _context.Users
            .Any(_ => _.RefreshToken == refreshtoken);

            if (tokenIsInUser)
            {
                return CreateRefreshToken();
            }
            return refreshtoken;
        }

        private ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false, //you might want to validate the audience and issuer depending on your use case
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["AppSettings:SecretKey"])),
                ValidateLifetime = false //here we are saying that we don't care about the token's expiration date
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);
            var jwtSecurityToken = securityToken as JwtSecurityToken;
            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Invalid token");
            return principal;
        }
        private Task<bool> checkEmailExistAsync(string email)
            => _context.Users.AnyAsync(x => x.Email == email);

        private Task<bool> checkUsernameExistAsync(string username)
            => _context.Users.AnyAsync(x => x.Email == username);

        private string CheckPasswordStrength(string pass)
        {
            StringBuilder sb = new StringBuilder();
            if (pass.Length < 9)
                sb.Append("Minimum password length should be 8" + Environment.NewLine);
            if (!(Regex.IsMatch(pass, "[a-z]") && Regex.IsMatch(pass, "[A-Z]") && Regex.IsMatch(pass, "[0-9]")))
                sb.Append("Password should be AlphaNumeric" + Environment.NewLine);
            if (!Regex.IsMatch(pass, "[<,>,@,!,#,$,%,^,&,*,(,),_,+,\\[,\\],{,},?,:,;,|,',\\,.,/,~,`,-,=]"))
                sb.Append("Password should contain special charcter" + Environment.NewLine);
            return sb.ToString();
        }
    }
}

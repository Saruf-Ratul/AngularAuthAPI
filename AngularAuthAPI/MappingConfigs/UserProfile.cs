using AngularAuthAPI.Models;
using AngularAuthAPI.Models.DTO_s;
using AutoMapper;

namespace AngularAuthAPI.MappingConfigs
{
    public class UserProfile: Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
            CreateMap<User, RegisterDto>();
            CreateMap<RegisterDto, User>();

        }
    }
}

using AngularAuthAPI.Context;
using AngularAuthAPI.Interface;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PHubApi.Helpers;
using Microsoft.AspNetCore.Components;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using Common.Helpers;
using AngularAuthAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AngularAuthAPI.Service;

namespace AngularAuthAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApoinmentController : ControllerBase
    {
        private readonly IApoinment _ApoinmentService;
        ApiReturnObj returnObj = new ApiReturnObj();
        private readonly AppDbContext _db = new AppDbContext();
        public ApoinmentController(IApoinment ApoinmentService, AppDbContext db)
        {
            _ApoinmentService = ApoinmentService;
            _db = db;
        }

        [HttpPost("add")]
        public IActionResult addData(Apoinment model)
        {
            using (var dbTransaction = _db.Database.BeginTransaction())
            {
                try
                {
                    var data = _ApoinmentService.addData(model, _db);
                    if (data)
                    {
                        dbTransaction.Commit();
                        returnObj.IsExecuted = true;
                        returnObj.Data = true;
                        returnObj.Message = MessageConst.Insert;
                        return Ok(returnObj);
                    }
                    else
                    {
                        dbTransaction.Rollback();
                        returnObj.IsExecuted = false;
                        returnObj.Data = null;
                        return Ok(returnObj);
                    }
                }
                catch (Exception ex)
                {
                    dbTransaction.Rollback();
                    returnObj.IsExecuted = false;
                    returnObj.Data = null;
                    return Ok(returnObj);
                }

            }

        }

        //User
        [HttpGet("userData/{username}")]
        public IActionResult UserData(string username)
        {
            try
            {
                var data = _ApoinmentService.UserData(username,_db);

                if (data != null)
                {
                    returnObj.IsExecuted = true;
                    returnObj.Data = data;
                    return Ok(returnObj);
                }
                else
                {
                    returnObj.IsExecuted = false;
                    returnObj.Message = MessageConst.NotFound;
                    returnObj.Data = null;
                    return Ok(returnObj);
                }
            }
            catch (Exception ex)
            {
                returnObj.IsExecuted = false;
                returnObj.Message = ex.Message;
                returnObj.Data = null;
                return Ok(returnObj);
            }

        }



    }
}

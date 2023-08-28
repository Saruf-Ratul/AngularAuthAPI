using AngularAuthAPI.Context;
using AngularAuthAPI.Interface;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PHubApi.Helpers;
using Microsoft.AspNetCore.Components;
using RouteAttribute = Microsoft.AspNetCore.Components.RouteAttribute;
using Common.Helpers;
using AngularAuthAPI.Models;

namespace AngularAuthAPI.Controllers
{
    [Route("api")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboard _DashboardService;
        ApiReturnObj returnObj = new ApiReturnObj();
        private readonly AppDbContext _db = new AppDbContext();
        public DashboardController(IDashboard DashboardService, AppDbContext db)
        {
            _DashboardService = DashboardService;
            _db = db;
        }

        [HttpGet("dashboard/view")]
        public IActionResult GetAll()
        {
            try
            {
                var data = _DashboardService.GetAll(_db);

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

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

namespace AngularAuthAPI.Controllers
{
    [Route("api/[controller]")]
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

        [HttpGet("view")]
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

        [HttpPost("add")]
        public IActionResult addData(Dashboard model)
        {
            using (var dbTransaction = _db.Database.BeginTransaction())
            {
                try
                {
                    var data = _DashboardService.addData(model, _db);
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

    }
}

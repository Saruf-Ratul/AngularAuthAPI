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
using Newtonsoft.Json;

namespace AngularAuthAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class tbAppointmentController : ControllerBase
    {
        private readonly ItbAppointment _tbAppointmentService;
        ApiReturnObj returnObj = new ApiReturnObj();
        private readonly AppDbContext _db = new AppDbContext();
        public tbAppointmentController(ItbAppointment tbAppointmentService, AppDbContext db)
        {
            _tbAppointmentService = tbAppointmentService;
            _db = db;
        }
        //tbAppointment
        [HttpGet("view")]
        public IActionResult GetAll()
        {
            try
            {
                var data = _tbAppointmentService.GetAll(_db);

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
        public IActionResult addData(tbAppointment model)
        {
            using (var dbTransaction = _db.Database.BeginTransaction())
            {
                try
                {
                    var data = _tbAppointmentService.addData(model, _db);
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

        [HttpPut("find/{app_ID}")]
        public IActionResult approvedData(decimal app_ID, tbAppointment model)
        {
            using (var dbTransaction = _db.Database.BeginTransaction())
            {
                try
                {
                    var message = "";
                    //var oldData = _tbAppointmentService.approvedData((decimal)model.app_ID, _db);
                    //string oldjson = JsonConvert.SerializeObject(oldData);

                    var data = _tbAppointmentService.approvedData(model, _db);
                    if (data)
                    {
                        dbTransaction.Commit();
                        returnObj.IsExecuted = true;
                        returnObj.Data = true;
                        returnObj.Message = message;
                        return Ok(returnObj);
                    }
                    else
                    {
                        dbTransaction.Rollback();
                        returnObj.IsExecuted = false;
                        returnObj.Message = MessageConst.UpdateError;
                        returnObj.Data = null;
                        return Ok(returnObj);
                    }
                }
                catch (Exception ex)
                {
                    dbTransaction.Rollback();
                    if (ex.InnerException != null)
                    {
                        returnObj.Message = ex.InnerException.Message;
                    }
                    else
                    {
                        returnObj.Message = ex.Message;
                    }
                    returnObj.IsExecuted = false;
                    returnObj.Data = null;
                    return Ok(returnObj);
                }

            }
        }


        //tbAppType
        [HttpGet("view_tbAppType")]
        public IActionResult GetAlltbAppType()
        {
            try
            {
                var data = _tbAppointmentService.GetAlltbAppType(_db);

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

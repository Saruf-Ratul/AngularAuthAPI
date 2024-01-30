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
using Microsoft.EntityFrameworkCore;
using AngularAuthAPI.Migrations;
using EmployeeMaster = AngularAuthAPI.Models.EmployeeMaster;

namespace AngularAuthAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeMasterController : ControllerBase
    {
        private readonly IEmployeeMaster _EmployeeMasterService;
        ApiReturnObj returnObj = new ApiReturnObj();
        private readonly AppDbContext _db = new AppDbContext();
        public EmployeeMasterController(IEmployeeMaster EmployeeMasterService, AppDbContext db)
        {
            _EmployeeMasterService = EmployeeMasterService;
            _db = db;
        }

        //EmployeeMaster
        [HttpGet("view")]
        public IActionResult GetAll()
        {
            try
            {
                var data = _EmployeeMasterService.GetAll(_db);

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
        public IActionResult addData(EmployeeMaster model)
        {
            using (var dbTransaction = _db.Database.BeginTransaction())
            {
                try
                {
                    var data = _EmployeeMasterService.addData(model, _db);
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

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(string id)
        {
            var data = _EmployeeMasterService.Delete(id);
            if (data)
            {
                returnObj.IsExecuted = true;
                returnObj.Message = MessageConst.Delete;
                returnObj.Data = true;
                return Ok(returnObj);
            }
            else
            {
                returnObj.IsExecuted = false;
                returnObj.Data = null;
                return Ok(returnObj);
            }
        }

    }
}

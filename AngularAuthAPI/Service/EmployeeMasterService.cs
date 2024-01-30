using AngularAuthAPI.Context;
using AngularAuthAPI.Interface;
using AngularAuthAPI.Migrations;
using AngularAuthAPI.Models;
using Common.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using static AngularAuthAPI.Context.AppDbContext;

namespace AngularAuthAPI.Service
{
    public class EmployeeMasterService : IEmployeeMaster
    {
        private readonly AppDbContext _db;
        public EmployeeMasterService(AppDbContext db)
        {
            _db = db;
        }
        //EmployeeMaster
        public dynamic GetAll(AppDbContext _db)
        {
            var data = _db.EmployeeMaster.ToList();
            return data;
        }

        public bool addData(Models.EmployeeMaster model, AppDbContext _db)
        {
            var ComputerName = System.Environment.MachineName;
            var ComputerUserName = System.Environment.UserName;
            string? AppID = _db.EmployeeMaster
                .Select(a => (string?)a.Id)
                .Max();
            if (AppID == null)
            {
                AppID = "1";
            }
            else
            {
                AppID = AppID + 1;
            }

            bool isSaved = false;
            var obj = new Models.EmployeeMaster();
            obj.Id = AppID;
            obj.CompanyCode = model.CompanyCode;
            obj.EmployeeCode = model.EmployeeCode;
            obj.EmployeeName = model.EmployeeName;
            obj.Degination = model.Degination;
            obj.Department = model.Department;
            obj.PhoneNumber = model.PhoneNumber;
            obj.EmailAddress = model.EmailAddress;
            obj.UserName = model.UserName;
            obj.ComputerName = ComputerName;
            obj.ComputerUserName = ComputerUserName;
            obj.SysDate = DateTime.Now;
            _db.EmployeeMaster.Add(obj);
            _db.SaveChanges();
            isSaved = true;
            return isSaved;
        }


        public bool Delete(string id)
        {
            bool isSaved = false;
            try
            {
                var data = _db.EmployeeMaster.FirstOrDefault(x => x.Id == id);

                if (data != null)
                {
                    _db.EmployeeMaster.Remove(data);
                    _db.SaveChanges();
                }
                isSaved = true;
            }
            catch (Exception ex)
            {
                isSaved = false;
            }
            return isSaved;
        }




    }
}

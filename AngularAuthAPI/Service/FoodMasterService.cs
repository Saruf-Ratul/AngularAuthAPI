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
    public class FoodMasterService : IFoodMaster
    {
        private readonly AppDbContext _db;
        public FoodMasterService(AppDbContext db)
        {
            _db = db;
        }
        //FoodMaster
        public dynamic GetAll(AppDbContext _db)
        {
            var data = _db.FoodMaster.ToList();
            return data;
        }

        public bool addData(Models.FoodMaster model, AppDbContext _db)
        {
            var ComputerName = System.Environment.MachineName;
            var ComputerUserName = System.Environment.UserName;
            var SoftwareLoginUser = System.Security.Principal.WindowsIdentity.GetCurrent().Name;

            string InsertId = _db.FoodMaster
                .Select(a => (string?)a.InsertId)
                .Max(); 

            if (string.IsNullOrEmpty(InsertId))
            {
                InsertId = "1";
            }
            else
            {
                InsertId = (int.Parse(InsertId) + 1).ToString();
            }

            bool isSaved = false;

            var obj = new Models.FoodMaster();
            obj.InsertId = InsertId;
            obj.CompanyCode = "200";
            obj.EmployeeCode = model.EmployeeCode;
            obj.EmployeeName = model.EmployeeName;
            obj.TypeId = model.TypeId;
            obj.Amount = model.Amount;
            obj.MealFor = model.MealFor;
            obj.UserName = SoftwareLoginUser;
            obj.ComputerName = ComputerName;
            obj.ComputerUserName = ComputerUserName;
            obj.SysDate = DateTime.Now;
            _db.FoodMaster.Add(obj);

            var objDF = new Models.DailyFood();
            objDF.InsertId = InsertId;
            objDF.CompanyCode = "200";
            objDF.EmployeeCode = model.EmployeeCode;
            objDF.TypeId = model.TypeId;
            objDF.TypeDetails = model.MealFor;
            objDF.UserName = SoftwareLoginUser;
            objDF.ComputerName = ComputerName;
            objDF.ComputerUserName = ComputerUserName;
            objDF.SysDate = DateTime.Now;
            _db.DailyFood.Add(objDF);

            var objAC = new Models.Account();
            objAC.InsertId = InsertId;
            objAC.CompanyCode = "200";
            objAC.EmployeeCode = model.EmployeeCode;
            objAC.NoOfFood = "1";
            objAC.TypeId = model.TypeId;
            objAC.Amount = model.Amount;
            objAC.UserName = SoftwareLoginUser;
            objAC.ComputerName = ComputerName;
            objAC.ComputerUserName = ComputerUserName;
            objAC.SysDate = DateTime.Now;
            _db.Account.Add(objAC);

            _db.SaveChanges();
            isSaved = true;
            return isSaved;
        }



        public bool Delete(string EmployeeCode)
        {
            bool isSaved = false;
            try
            {
                var data = _db.FoodMaster.FirstOrDefault(x => x.EmployeeCode == EmployeeCode);

                if (data != null)
                {
                    _db.FoodMaster.Remove(data);
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

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
    public class ServiceTypeService : IServiceType
    {
        private readonly AppDbContext _db;
        public ServiceTypeService(AppDbContext db)
        {
            _db = db;
        }
        //ServiceType
        public dynamic GetAll(AppDbContext _db)
        {
            var data = _db.ServiceType.ToList();
            return data;
        }

        public bool addData(Models.ServiceType model, AppDbContext _db)
        {
            var ComputerName = System.Environment.MachineName;
            var ComputerUserName = System.Environment.UserName;

            bool isSaved = false;
            var obj = new Models.ServiceType();
            obj.TypeId = model.TypeId;
            obj.TypeId = model.TypeId;
            obj.TypeName = model.TypeName;
            obj.TypeDetails = model.TypeDetails;
            obj.isActive = model.isActive;
            obj.CreateDate = DateTime.Now;
            obj.UserName = model.UserName;
            obj.ComputerName = ComputerName;
            obj.ComputerUserName = ComputerUserName;
            obj.SysDate = DateTime.Now;
            _db.ServiceType.Add(obj);
            _db.SaveChanges();
            isSaved = true;
            return isSaved;
        }


        public bool Delete(string TypeId)
        {
            bool isSaved = false;
            try
            {
                var data = _db.ServiceType.FirstOrDefault(x => x.TypeId == TypeId);

                if (data != null)
                {
                    _db.ServiceType.Remove(data);
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

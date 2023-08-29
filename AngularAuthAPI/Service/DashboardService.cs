using AngularAuthAPI.Context;
using AngularAuthAPI.Interface;
using AngularAuthAPI.Models;
using Common.Helpers;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using static AngularAuthAPI.Context.AppDbContext;

namespace AngularAuthAPI.Service
{
    public class DashboardService : IDashboard
    {
        private readonly AppDbContext _db;
        public DashboardService(AppDbContext db)
        {
            _db = db;
        }

        public dynamic GetAll(AppDbContext _db)
        {
            var data = from a in _db.Dashboards
                                    .AsQueryable()
                                    .Where(x => x.CompanyCode == ConstantValue.CompanyCode)
                                    .ToList()
                       select new
                       {
                           id = a.Id,
                           name = a.Name,
                           description = a.Description
                       };

            return data;
        }

        public bool addData(Dashboard model, AppDbContext _db)
        {
            bool isSaved = false;
            var obj = new Dashboard();
            obj.Id = model.Id;
            obj.CompanyCode = ConstantValue.CompanyCode;
            obj.Name = model.Name;
            obj.Description = model.Description;
            _db.Dashboards.Add(obj);
            _db.SaveChanges();
            isSaved = true;
            return isSaved;
        }

    }
}

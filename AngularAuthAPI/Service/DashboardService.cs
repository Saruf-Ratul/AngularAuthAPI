using AngularAuthAPI.Context;
using AngularAuthAPI.Interface;
using AngularAuthAPI.Models;
using Common.Helpers;
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
                                    .Where(x => x.Id == ConstantValue.CompanyCode)
                                    .ToList()
                       select new
                       {
                           id = a.Id,
                           name = a.Name,
                           description = a.Description
                       };

            return data;

            throw new NotImplementedException();
        }

    }
}

using AngularAuthAPI.Context;
using AngularAuthAPI.Models;
using System.Security.Principal;

namespace AngularAuthAPI.Interface
{
    public interface IDashboard
    {
        dynamic GetAll(AppDbContext _db);
        bool addData(Dashboard model, AppDbContext _db);
    }
}

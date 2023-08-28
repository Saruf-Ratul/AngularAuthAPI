using AngularAuthAPI.Context;
using AngularAuthAPI.Models;
using System.Security.Principal;

namespace AngularAuthAPI.Interface
{
    public class IDashboard
    {
        //internal dynamic GetAll(AppDbContext db)
        //{
        //    throw new NotImplementedException();
        //}

        dynamic GetAll(AppDbContext _db);
    }
}

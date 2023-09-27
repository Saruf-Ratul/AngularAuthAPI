using AngularAuthAPI.Context;
using AngularAuthAPI.Models;
using System.Security.Principal;

namespace AngularAuthAPI.Interface
{
    public interface IApoinment
    {
        bool addData(Apoinment model, AppDbContext _db);
        dynamic UserData(string username, AppDbContext _db);
    }
}

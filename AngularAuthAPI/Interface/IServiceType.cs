using AngularAuthAPI.Context;
using AngularAuthAPI.Models;
using System.Security.Principal;

namespace AngularAuthAPI.Interface
{
    public interface IServiceType
    {
        dynamic GetAll(AppDbContext _db);
        bool addData(ServiceType model, AppDbContext _db);
        bool Delete(string TypeId);

    }
}

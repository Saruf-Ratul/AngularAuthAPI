using AngularAuthAPI.Context;
using AngularAuthAPI.Models;
using System.Security.Principal;

namespace AngularAuthAPI.Interface
{
    public interface IEmployeeMaster
    {
        dynamic GetAll(AppDbContext _db);
        bool addData(EmployeeMaster model, AppDbContext _db);
        bool Delete(string id);

    }
}

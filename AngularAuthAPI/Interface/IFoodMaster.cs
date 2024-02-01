using AngularAuthAPI.Context;
using AngularAuthAPI.Models;
using System.Security.Principal;

namespace AngularAuthAPI.Interface
{
    public interface IFoodMaster
    {
        dynamic GetAll(AppDbContext _db);
        bool addData(FoodMaster model, AppDbContext _db);
        bool Delete(string TypeId);

    }
}

using AngularAuthAPI.Context;
using AngularAuthAPI.Models;
using System.Security.Principal;

namespace AngularAuthAPI.Interface
{
    public interface ItbAppointment
    {
        dynamic GetAll(AppDbContext _db);
        bool addData(tbAppointment model, AppDbContext _db);
        dynamic GetAlltbAppType(AppDbContext _db);
        bool approvedData(tbAppointment model, AppDbContext _db);

    }
}

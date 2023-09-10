using AngularAuthAPI.Context;
using AngularAuthAPI.Interface;
using AngularAuthAPI.Models;
using Common.Helpers;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using static AngularAuthAPI.Context.AppDbContext;

namespace AngularAuthAPI.Service
{
    public class ApoinmentService : IApoinment
    {
        private readonly AppDbContext _db;
        public ApoinmentService(AppDbContext db)
        {
            _db = db;
        }

        public bool addData(Apoinment model, AppDbContext _db)
        {
            bool isSaved = false;
            var obj = new Apoinment();
            obj.Id = model.Id;
            obj.CompanyCode = ConstantValue.CompanyCode;
            obj.CarName = model.CarName;
            obj.Description = model.Description;
            obj.ModelYear = model.ModelYear;
            obj.RuningMilage = model.RuningMilage;
            obj.Problem = model.Problem;
            obj.Note = model.Note;
            obj.PhoneNumber = model.PhoneNumber;
            obj.Email = model.Email;
            obj.Address = model.Address;
            _db.Apoinments.Add(obj);
            _db.SaveChanges();
            isSaved = true;
            return isSaved;
        }

    }
}

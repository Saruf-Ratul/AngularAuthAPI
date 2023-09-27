using AngularAuthAPI.Context;
using AngularAuthAPI.Interface;
using AngularAuthAPI.Models;
using Common.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using static AngularAuthAPI.Context.AppDbContext;

namespace AngularAuthAPI.Service
{
    public class tbAppointmentService : ItbAppointment
    {
        private readonly AppDbContext _db;
        public tbAppointmentService(AppDbContext db)
        {
            _db = db;
        }
        //tbAppointment
        public dynamic GetAll(AppDbContext _db)
        {
            var data = _db.tbAppointment.ToList();
            return data;
        }

        public bool addData(tbAppointment model, AppDbContext _db)
        {
            var ComputerName = System.Environment.MachineName;
            var ComputerUserName = System.Environment.UserName;
            int? AppID = _db.tbAppointment
                .Select(a => (int?)a.App_ID)
                .Max();
            if (AppID == null)
            {
                AppID = 1;
            }
            else
            {
                AppID = AppID + 1;
            }

            bool isSaved = false;
            var obj = new tbAppointment();
            obj.App_ID = (decimal)AppID;
            obj.Schedule_Date = model.Schedule_Date;
            obj.Schedule_Time = model.Schedule_Time;
            obj.End_Time = model.End_Time;
            obj.Cust_Name = model.Cust_Name;
            obj.Address = model.Address;
            obj.vReg_No = model.vReg_No;
            obj.Model = model.Model;
            obj.Model_Year = model.Model_Year;
            obj.KM = model.KM;
            obj.Reminder1_Date = model.Reminder1_Date;
            obj.Reminder2_Date = model.Reminder2_Date;
            obj.Reminder3_Date = model.Reminder3_Date;
            obj.CustomerRequest = model.CustomerRequest;
            obj.App_TypeId = model.App_TypeId;
            obj.App_Serial = model.App_Serial;
            obj.APP_Confirm = model.APP_Confirm;
            obj.Appby_Secu_EMPID = model.Appby_Secu_EMPID;
            obj.Confirmby_Secu_EMPID = model.Confirmby_Secu_EMPID;
            obj.vPhone = model.vPhone;
            obj.email = model.email;
            obj.App_Entry_Date = model.App_Entry_Date;
            obj.Print_count = model.Print_count;
            obj.Level_Id = model.Level_Id;
            obj.Bay_Id = model.Bay_Id;
            obj.EMPID = model.EMPID;
            obj.Remarks = model.Remarks;
            obj.MobleNO_SMS = model.MobleNO_SMS;
            obj.APP_Re_Confirm = model.APP_Re_Confirm;
            obj.Chesis_No = model.Chesis_No;
            obj.UserName = model.UserName;
            obj.Computer_Name = ComputerName;
            obj.Computer_UserName = ComputerUserName;
            obj.SysDate = DateTime.Now;
            _db.tbAppointment.Add(obj);
            _db.SaveChanges();
            isSaved = true;
            return isSaved;
        }

        public bool ApproveAppointment(decimal app_ID)
        {
            try
            {
                var oldData = _db.tbAppointment.FirstOrDefault(x => x.App_ID == app_ID);
                if (oldData != null)
                {
                    oldData.APP_Confirm = true;
                    _db.Entry(oldData).State = EntityState.Modified;
                    _db.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to approve appointment.", ex);
            }
        }

        public bool Delete(decimal app_ID)
        {
            bool isSaved = false;
            try
            {
                var data = _db.tbAppointment.FirstOrDefault(x => x.App_ID == app_ID);

                if (data != null)
                {
                    _db.tbAppointment.Remove(data);
                    _db.SaveChanges();
                }
                isSaved = true;
            }
            catch (Exception ex)
            {
                isSaved = false;
            }
            return isSaved;
        }


        //tbAppType
        public dynamic GetAlltbAppType(AppDbContext _db)
        {
            var data = _db.tbAppType.ToList();
            return data;
        }
    }
}

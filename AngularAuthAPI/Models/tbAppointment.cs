namespace AngularAuthAPI.Models
{
    public class tbAppointment
    {
        public decimal App_ID { get; set; }
        public DateTime? Schedule_Date { get; set; }
        public DateTime? Schedule_Time { get; set; }
        public DateTime? End_Time { get; set; }
        public string Cust_Name { get; set; }
        public string Address { get; set; }
        public string vReg_No { get; set; }
        public string Model { get; set; }
        public string Model_Year { get; set; }
        public decimal? KM { get; set; }
        public DateTime? Reminder1_Date { get; set; }
        public DateTime? Reminder2_Date { get; set; }
        public DateTime? Reminder3_Date { get; set; }
        public string CustomerRequest { get; set; }
        public byte? App_TypeId { get; set; }
        public int? App_Serial { get; set; }
        public bool? APP_Confirm { get; set; }
        public int? Appby_Secu_EMPID { get; set; }
        public int? Confirmby_Secu_EMPID { get; set; }
        public string vPhone { get; set; }
        public string email { get; set; }
        public DateTime? App_Entry_Date { get; set; }
        public byte? Print_count { get; set; }
        public int? Level_Id { get; set; }
        public int? Bay_Id { get; set; }
        public int? EMPID { get; set; }
        public string Remarks { get; set; }
        public string MobleNO_SMS { get; set; }
        public bool? APP_Re_Confirm { get; set; }
        public string Chesis_No { get; set; }
        public string UserName { get; set; }
        public string Computer_Name { get; set; }
        public string Computer_UserName { get; set; }
        public DateTime? SysDate { get; set; }

    }
}

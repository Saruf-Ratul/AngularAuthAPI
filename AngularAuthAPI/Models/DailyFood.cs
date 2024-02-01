using System.ComponentModel.DataAnnotations.Schema;

namespace AngularAuthAPI.Models
{
    public class DailyFood
    {
        public string Id { get; set; } 
        public string InsertId { get; set; }
        public string CompanyCode { get; set; }
        public string EmployeeCode { get; set; }
        public string TypeId { get; set; }
        public string TypeDetails { get; set; }
        public string UserName { get; set; }
        public string ComputerName { get; set; }
        public string ComputerUserName { get; set; }
        public DateTime? SysDate { get; set; }

        [ForeignKey("InsertId")]
        public FoodMaster FoodMaster { get; set; }

    }
}

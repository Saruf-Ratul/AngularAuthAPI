using System.ComponentModel.DataAnnotations;

namespace AngularAuthAPI.Models
{
    public class FoodMaster
    {
        public string Id { get; set; }
        public string InsertId { get; set; }
        public string CompanyCode { get; set; }
        public string EmployeeCode { get; set; }
        public string EmployeeName { get; set; }
        public string TypeId { get; set; }
        public string MealFor { get; set; }
        public string UserName { get; set; }
        public string ComputerName { get; set; }
        public string ComputerUserName { get; set; }
        public DateTime? SysDate { get; set; }
        public string Amount { get;  set; }
    }
}

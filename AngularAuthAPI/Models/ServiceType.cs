namespace AngularAuthAPI.Models
{
    public class ServiceType
    {
        public int Id { get; set; }
        public string TypeId { get; set; }
        public string Type { get; set; }
        public string TypeName { get; set; }
        public string TypeDetails { get; set; }
        public bool CostType { get; set; }
        public bool isActive { get; set; }
        public DateTime CreateDate { get; set; }
        public string UserName { get; set; }
        public string ComputerName { get; set; }
        public string ComputerUserName { get; set; }
        public DateTime? SysDate { get; set; }

    }
}

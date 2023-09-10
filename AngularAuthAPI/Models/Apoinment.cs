using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AngularAuthAPI.Models
{
    public class Apoinment
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string CompanyCode { get; set; }
        public string CarName { get; set; }
        public string Description { get; set; }
        public decimal ModelYear { get; set; }
        public decimal RuningMilage { get; set; }
        public string Problem { get; set; }
        public string Note { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }


    }
}

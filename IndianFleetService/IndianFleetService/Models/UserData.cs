using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VehicleConfigurator.Model
{
    public class UserData
    {
       
        [Key]

        public int UserId { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string? Password { get; set; }

        [Required]
        public string? EmailId { get; set; }

        [Required]
        public string? CompanyName { get; set; }

        [Required]
        public string? Address { get; set; }

        [Required]
        public string? Telephone { get; set; }

        [Required]
        public string? holding { get; set; }

        public IList<InvoiceHeader>? InvoiceHeaders { get; set; }
       

    }
}

using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VehicleConfigurator.Model
{
    public class InvoiceHeader
    {
        [Key]
        public int InvoiceId { get; set; } 
        public int Qty { get; set; }
        [ForeignKey("UserData ")]
        public int UserId { get; set; }
        public DateTime BillingDate { get; set; }
      
        public string? CompanyName { get; set; }
       
        public int Telephone { get; set; }
        public UserData? UserData { get; set; }
        public IList<InvoiceDetail>? InvoiceDetails { get;set; }
       

        /*public IList<UserData>CompanyName { get; set; }    
        public IList<UserData> Telephone { get;}
*/
    }
}

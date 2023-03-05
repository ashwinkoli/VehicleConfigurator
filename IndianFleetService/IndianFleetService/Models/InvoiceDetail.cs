using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using VehicleConfigurator.Model;

public class InvoiceDetail
{

    [Key]
    public int InvoiceDetailId { get; set; }

    [ForeignKey("InvoiceHeader")]
    public int? InvoiceId { get; set; }
    public String? VehicleDescription { get; set; }
    public int? AltCompId { get; set; }
    public InvoiceHeader? InvoiceHeader { get; set; }

}
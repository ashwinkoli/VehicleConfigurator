using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VehicleConfigurator.Model
{
    public class SegmentMaster
    {
        [Key]
        public int SegId { get; set;}
        public string? SegName { get; set;}
        //child class this is ree also
        public IList<MfgMaster>? MfgMasters { get;set; }
       
    }
}

using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VehicleConfigurator.Model
{
    public class MfgMaster
    {
        [Key]
        public int MfgId { get; set; }  

        public string? MfgName { get; set; }
        [ForeignKey("SegmentMaster")]
        public int SegId { get; set; }

    //reffereence for foreign key 
    public SegmentMaster? SegmentMaster { get; set; }
      public IList<ModelMaster>? ModelMasters { get; set; }
        
    }
}

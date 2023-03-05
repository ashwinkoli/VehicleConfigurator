using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VehicleConfigurator.Model
{
    public class ModelMaster
    {
        
        [Key]
        public int ModelId { get; set; }
        public string? ModelName { get; set; }
        [ForeignKey("MfgMaster")]
        public int MfgId { get; set; }
        
        public int MinQty { get; set; }
        public double BasicPrice { get; set; }
        public string? ImagPath { get; set; }
        
        public MfgMaster? MfgMaster { get; set; }
      
        public IList<VehicleDetail>? vehicleDetails { get; set; }
        public IList<AlternateComponentMaster>? AlternateComponentsMasters { get; set; }
        

    }
 
}
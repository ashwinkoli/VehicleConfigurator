using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VehicleConfigurator.Model
{
    public class ComponentMaster
    {
        [Key]

        [Column("compId")]
        public int CompId { get; set; }
        public string? CompName { get; set; }
        public IList<AlternateComponentMaster>? AlternateComponentMasters { get; set; }
        public IList<VehicleDetail>? vehicleDetails { get; set; }
      

    }
}
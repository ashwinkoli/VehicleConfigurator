using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VehicleConfigurator.Model
{
    public class VehicleDetail
    {
        [Key]       
        public int ConfiId { get; set; }

        [ForeignKey("ModelMaster")]
        public int ModelId { get; set; }
        [ForeignKey("ComponentMaster")]
        public int CompId { get; set; }
        public string? CompType { get; set; }
        public bool IsConfigurable { get; set; }
        public ModelMaster? ModelMaster { get; set; }
        public ComponentMaster? ComponentMaster { get; set; }


    }
}

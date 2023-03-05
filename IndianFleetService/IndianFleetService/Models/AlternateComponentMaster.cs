using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VehicleConfigurator.Model
{
    public class AlternateComponentMaster
    {
        [Key]
        public int AltId { get; set; }
        
        [ForeignKey("ModelMaster")]
        public int ModelId { get; set; }
        [ForeignKey("ComponentMaster")]
        public int? CompId { get; set; }
       
        public int? AltCompId { get; set; }

        public String? AltCompType { get; set; }

        public double DeltaPrice { get; set; }
        public  ComponentMaster? ComponentMaster { get; set; }
        public ModelMaster? ModelMaster { get; set; }


    }
}

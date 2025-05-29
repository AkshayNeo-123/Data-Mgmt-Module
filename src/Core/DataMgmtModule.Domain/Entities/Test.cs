using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMgmtModule.Domain.Entities
{
    public class Test:Common
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("Recipe")]
        public int RecipeNumber { get; set; }
        public Recipe Recipe { get; set; }
        public string? Comment { get; set; }
        public bool IsPublish { get; set; }
        public bool IsDelete { get; set; }
        public TemperatureProperty TemperatureProperty { get; set; }
        public FlammabilityProperties FlammabilityProperty { get; set; }
        public MechanicalProperty MechanicalProperty { get; set; }
        public GeneralProperties GeneralProperty { get; set; }
        public ElectricalProperties ElectricalProperty { get; set; }
        public Properties Properties { get; set; }



    }
}

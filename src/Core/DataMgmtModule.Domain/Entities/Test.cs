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
        public int Id { get; set; }
        [ForeignKey("Recipe")]
        public int RecipeNumber { get; set; }
        public Recipe Recipe { get; set; }
        public string? Comment { get; set; }
        public bool IsPublish { get; set; }
        public bool IsDelete { get; set; }
        public List<TemperatureProperty> TemperatureProperties { get; set; } = new();
        public List<FlammabilityProperties> FlammabilityProperties { get; set; } = new();
    }
}

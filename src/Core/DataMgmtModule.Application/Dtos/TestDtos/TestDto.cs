using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Domain.Entities;

namespace DataMgmtModule.Application.Dtos.TestDtos
{
    public class TestDto
    {
        public int Id { get; set; }
        public int RecipeNumber { get; set; }
        public string? Comment { get; set; }
        public bool IsPublish { get; set; }
        public string RecipeName { get; set; }
        public string MainPolymerName { get; set; }
        public bool FlammabilityProperties { get; set; } = false;
        public bool Property { get; set; } = false;
        public bool TemperatureProperties { get; set; } = false;
        public bool ElectricalProperties { get; set; } = false;
        public bool GeneralProperties { get; set; } = false;
        public bool MechanicalProperty { get; set; } = false;

    }
}

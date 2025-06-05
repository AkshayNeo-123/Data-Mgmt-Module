using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Application.Dtos.RecipeDtos;
using DataMgmtModule.Domain.Entities;

namespace DataMgmtModule.Application.Dtos.TestDtos
{
    public class CommonTestDto
    {
        //public int Id { get; set; }
        public int RecipeId { get; set; }
        public string RecipeName { get; set; }
        public string? Description { get; set; }
        //public RecipeProjectDTO RecipeProjectDTO { get; set; }
        public string ProjectNumber { get; set; }


        public MechanicalPropertyDto MechanicalPropertyDto { get; set; }
        public GeneralPropertyDto GeneralPropertyDto { get; set; }
        public TemperaturePropertyDto TemperaturePropertyDto { get; set; }
        public PropertiesDto PropertiesDto { get; set; }
        public FlammabilityPropertyDto FlammabilityPropertyDto
        {
            get;
            set;
        }
        public ElectricalPropertyDto ElectricalPropertyDto
        {
            get; set;
        }
    }
}

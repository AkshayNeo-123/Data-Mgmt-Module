using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMgmtModule.Application.Dtos.InjectionMolding
{
    public class InjectionMoldingDto
    {
        //public int Id { get; set; }

       
        //public int ProjectId { get; set; }
        //public string ProjectName { get; set; }  

        //public int RecipeId { get; set; }
        //public string RecipeName { get; set; }  
        // Other Fields
        public int? Repetition { get; set; }
        public string ReferenceAdditive { get; set; }

        public int ParameterSet { get; set; }
        public int? PreTreatment { get; set; }
        public decimal? DryingTemperature { get; set; }
        public decimal? DryingTime { get; set; }
        public decimal? ResidualMoisture { get; set; }
        public bool? NotMeasured { get; set; }
        public decimal? ProcessingMoisture { get; set; }
        public decimal? PlasticizingVolume { get; set; }
        public decimal? DecompressionVolume { get; set; }
        public decimal? SwitchingPoint { get; set; }
        public decimal? HoldingPressure { get; set; }
        public decimal? BackPressure { get; set; }
        public decimal? ScrewSpeed { get; set; }
        public decimal? InjectionSpeed { get; set; }
        public decimal? InjectionPressure { get; set; }
        public decimal? TemperatureZone { get; set; }
        public decimal? ExtraFeedSection { get; set; }
        public decimal? MeltTemperature { get; set; }
        public decimal? NozzleTemperature { get; set; }
        public decimal? MoldTemperature { get; set; }
    }
}

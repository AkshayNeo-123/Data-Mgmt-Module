using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMgmtModule.Application.Dtos.InjectionMolding
{
    public class UpdateInjectionMoldingDto
    {
        [Required]
        public string ProjectId { get; set; }
        [Required]

        public int ParameterSet { get; set; }
        [Required]

        public int RecipeId { get; set; }

        public int? Repetition { get; set; }
        public string? Additive { get; set; }
        public bool Reference { get; set; }


        //public int PreTreatment { get; set; }
        public bool PretreatmentNone { get; set; }
        public bool PretreatmentDryTest { get; set; }

        public decimal? DryingTemperature { get; set; }

        public decimal? DryingTime { get; set; }

        public decimal? ResidualMoisture { get; set; }

        public decimal? ProcessingMoisture { get; set; }
        public bool? NotMeasured { get; set; }



        public decimal? PlasticizingVolume { get; set; }

        public decimal? DecompressionVolume { get; set; }

        public decimal? HoldingPressure { get; set; }
        public decimal? SwitchingPoint { get; set; }
        public decimal? ScrewSpeed { get; set; }

        public decimal? InjectionSpeed { get; set; }

        public decimal? InjectionPressure { get; set; }



        //public decimal? BackPressure { get; set; }


        public decimal? TemperatureZone { get; set; }

        //public decimal? ExtraFeedSection { get; set; }

        public decimal? MeltTemperature { get; set; }

        public decimal? NozzleTemperature { get; set; }

        public decimal? MouldTemperature { get; set; }
        public int? ModifiedBy { get; set; }
    }

}

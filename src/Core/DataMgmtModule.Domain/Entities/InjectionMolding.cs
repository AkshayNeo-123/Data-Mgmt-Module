using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataMgmtModule.Domain.Entities;

public partial class InjectionMolding : Common
{
    public int Id { get; set; }

    public string ProjectId { get; set; }

    public int ParameterSet { get; set; }

    public int RecipeId { get; set; }
    [ForeignKey("RecipeId")]
    public virtual Recipe Recipe { get; set; } = null!;

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

    //public virtual Projects Project { get; set; } = null!;

    
    public bool IsDelete { get; set; }




} 
    //public int
//Id { get; set; }

    //// Multi-select field, stored as comma-separated values or use a separate table for normalization
    //public string ProjectId { get; set; }  // e.g. "P123,P124"

    //public string ParameterSet { get; set; }
    //public string RecipeNumber { get; set; }
    //public int Repetition { get; set; }
    //public string Additive { get; set; }

    //// Pretreatment options
    //public bool PretreatmentNone { get; set; }
    //public bool PretreatmentDryTest { get; set; }
    //public float? DryingTemperature { get; set; }
    //public float? DryingTime { get; set; }
    //public float? ResidualMoisture { get; set; }
    //public float? ProcessingMoisture { get; set; }
    //public bool NotMeasured { get; set; }

    //// Injection molding parameters
    //public float? PlasticizingVolume { get; set; }
    //public float? DecompressionVolume { get; set; }
    //public float? HoldingPressure { get; set; }
    //public float? SwitchingPoint { get; set; }
    //public float? ScrewSpeed { get; set; }
    //public float? InjectionSpeed { get; set; }
    //public float? InjectionPressure { get; set; }

    //// Temperature settings
    //public float? TemperatureZone { get; set; }
    //public float? MeltTemperature { get; set; }
    //public float? NozzleTemperature { get; set; }
    //public float? MouldTemperature { get; set; }

using System;
using System.Collections.Generic;

namespace DataMgmtModule.Domain.Entities;

public partial class Dosage : Common
{
    public int DosageId { get; set; }
    public int? CompoundingId { get; set; }

    public int SpeedSideFeeder1 { get; set; }
    public int SpeedSideFeeder2 { get; set; }

    public string? UploadScrewconfig { get; set; }

    public int? ScrewSpeed { get; set; }
    public int? Torque { get; set; }
    public int? Pressure { get; set; }
    public int? TotalOutput { get; set; }
    public int? Granulator { get; set; }
    public int? BulkDensity { get; set; }
    public int? CoolingSection { get; set; }

    public string? Notes { get; set; }

    public bool? MeltPump { get; set; }
    public bool? NozzlePlate { get; set; }
    public bool? Premix { get; set; }
    public bool? UnderwaterPelletizer { get; set; }

    // Newly added temperature columns
    public decimal? Temp1 { get; set; }
    public decimal? Temp2 { get; set; }
    public decimal? Temp3 { get; set; }
    public decimal? Temp4 { get; set; }
    public decimal? Temp5 { get; set; }
    public decimal? Temp6 { get; set; }
    public decimal? Temp7 { get; set; }
    public decimal? Temp8 { get; set; }
    public decimal? Temp9 { get; set; }
    public decimal? Temp10 { get; set; }
    public decimal? Temp11 { get; set; }
    public decimal? Temp12 { get; set; }

    // Boolean flags
    public bool? ScrewConfigStadard { get; set; }
    public bool? ScrewConfigModified { get; set; }

    public bool? DeggassingStadard { get; set; }
    public bool? DeggassingVaccuum { get; set; }
    public bool? DeggassingNone { get; set; }
    public bool? DeggassingFET { get; set; }

    public string? PremixNote { get; set; }

    public decimal? TemperatureWaterBath1 { get; set; }
    public decimal? TemperatureWaterBath2 { get; set; }
    public decimal? TemperatureWaterBath3 { get; set; }

    public virtual CompoundingDatum? Compounding { get; set; }
}

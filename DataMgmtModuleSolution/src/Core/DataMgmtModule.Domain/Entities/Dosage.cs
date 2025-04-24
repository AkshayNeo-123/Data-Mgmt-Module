using System;
using System.Collections.Generic;

namespace DataMgmtModule.Domain.Entities;

public partial class Dosage
{
    public int DosageId { get; set; }

    public int? CompoundingId { get; set; }

    public int SpeedSideFeeder1 { get; set; }

    public int SpeedSideFeeder2 { get; set; }

    public string? UploadScrewconfig { get; set; }

    public int? TemperatureProfile { get; set; }

    public int? ScrewConfig { get; set; }

    public int? Deggassing { get; set; }

    public int? ScrewSpeed { get; set; }

    public int? Torque { get; set; }

    public int? Pressure { get; set; }

    public int? TotalOutput { get; set; }

    public int? Granulator { get; set; }

    public int? BulkDensity { get; set; }

    public int? CoolingSection { get; set; }

    public decimal? TemperatureWaterBath { get; set; }

    public string? Notes { get; set; }

    public int? MeltPump { get; set; }

    public int? NozzlePlate { get; set; }

    public int? Premix { get; set; }

    public DateTime? CreatedDate { get; set; }
    public int? CreatedBy { get; set; }
    public int? ModifiedBy { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public int? UnderwaterPelletizer { get; set; }

    public virtual CompoundingDatum? Compounding { get; set; }
}

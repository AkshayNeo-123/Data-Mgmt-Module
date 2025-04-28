using System;
using System.Collections.Generic;

namespace DataMgmtModule.Domain.Entities;

public partial class Materials: Common
{
    public int MaterialId { get; set; }

    public int? MaterialsType { get; set; }

    public string? Designation { get; set; }

    public int ManufacturerId { get; set; }

    public decimal? Quantity { get; set; }

    public decimal? Density { get; set; }

    public string? TestMethod { get; set; }

    public string? TdsfilePath { get; set; }

    public string? MsdsfilePath { get; set; }

    public int? StorageLocation { get; set; }

    public string? Description { get; set; }

    public int? MVR_MFR { get; set; }

    public virtual Contact Manufacturer { get; set; } = null!;

    public int AdditiveId { get; set; }

    public int MainPolymerId { get; set; }

    public virtual Additive Additive { get; set; } = null!;

    public virtual MainPolymer MainPolymer { get; set; } = null!;

}

using System;
using System.Collections.Generic;

namespace DataMgmtModule.Domain.Entities;

public partial class CompoundLog
{
    public int? CompoundingId { get; set; }

    public int? RecipeId { get; set; }

    public int ParameterSet { get; set; }

    public DateOnly? Date { get; set; }

    public string? Notes { get; set; }

    public int? Repetation { get; set; }

    public bool? PretreatmentNone { get; set; }
    public bool? PretreatmentDrying { get; set; }
    public decimal Temperature { get; set; }

    public TimeSpan? Duration { get; set; }

    public decimal? ResidualIm { get; set; }

    public bool? NotMeasured { get; set; }

    public int? DeletedBy { get; set; }

    public DateTime? DeletedDate { get; set; }

    public int LogId { get; set; }
}

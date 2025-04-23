using System;
using System.Collections.Generic;

namespace DataMgmtModule.Domain.Entities;

public partial class CompoundingDatum
{
    public int CompoundingId { get; set; }

    public int? RecipeId { get; set; }

    public int ParameterSet { get; set; }

    public DateOnly? Date { get; set; }

    public string? Notes { get; set; }

    public int? Repetation { get; set; }

    public int Pretreatment { get; set; }

    public decimal Temperature { get; set; }

    public TimeSpan? Duration { get; set; }

    public decimal? ResidualM { get; set; }

    public int? NotMeasured { get; set; }

    public virtual ICollection<CompoundingComponent> CompoundingComponents { get; set; } = new List<CompoundingComponent>();

    public virtual ICollection<Dosage> Dosages { get; set; } = new List<Dosage>();

    public virtual Recipe? Recipe { get; set; }
}

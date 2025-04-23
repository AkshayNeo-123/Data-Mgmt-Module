using System;
using System.Collections.Generic;

namespace DataMgmtModule.Domain.Entities;

public partial class Recipe
{
    public int ReceipeId { get; set; }

    public string? ProductName { get; set; }

    public string? Comments { get; set; }

    public int? ProjectId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int AdditiveId { get; set; }

    public int MainPolymerId { get; set; }

    public virtual Additive Additive { get; set; } = null!;

    public virtual ICollection<CompoundingComponent> CompoundingComponents { get; set; } = new List<CompoundingComponent>();

    public virtual ICollection<CompoundingDatum> CompoundingData { get; set; } = new List<CompoundingDatum>();

    public virtual ICollection<InjectionMolding> InjectionMoldings { get; set; } = new List<InjectionMolding>();

    public virtual MainPolymer MainPolymer { get; set; } = null!;

    public virtual Projects? Project { get; set; }

    public virtual ICollection<RecipeComponent> RecipeComponents { get; set; } = new List<RecipeComponent>();
}

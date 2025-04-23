using System;
using System.Collections.Generic;

namespace DataMgmtModule.Domain.Entities;

public partial class Component
{
    public int Id { get; set; }

    public string ComponentName { get; set; } = null!;

    public virtual ICollection<CompoundingComponent> CompoundingComponents { get; set; } = new List<CompoundingComponent>();

    public virtual ICollection<RecipeComponent> RecipeComponents { get; set; } = new List<RecipeComponent>();
}

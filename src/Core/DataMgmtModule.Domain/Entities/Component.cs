using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DataMgmtModule.Domain.Entities;

public partial class Component:Common
{
    public int Id { get; set; }

    public string ComponentName { get; set; } = null!;

    public virtual ICollection<CompoundingComponent> CompoundingComponents { get; set; } = new List<CompoundingComponent>();
    [JsonIgnore]
    public virtual ICollection<RecipeComponent> RecipeComponents { get; set; } = new List<RecipeComponent>();
}

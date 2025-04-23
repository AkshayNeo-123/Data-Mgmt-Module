using System;
using System.Collections.Generic;

namespace DataMgmtModule.Domain.Entities;

public partial class MainPolymer
{
    public int Id { get; set; }

    public string PolymerName { get; set; } = null!;

    public virtual ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();
}

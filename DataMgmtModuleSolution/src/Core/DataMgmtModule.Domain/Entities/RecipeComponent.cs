using System;
using System.Collections.Generic;

namespace DataMgmtModule.Domain.Entities;

public partial class RecipeComponent
{
    public int RecipeComponentId { get; set; }

    public int? RecipeId { get; set; }

    public decimal? WtPercent { get; set; }

    public decimal? ValPercent { get; set; }

    public decimal? Density { get; set; }

    public bool? Mp { get; set; }

    public bool? Mf { get; set; }

    public int ComponentId { get; set; }

    public virtual Component Component { get; set; } = null!;

    public virtual Recipe? Recipe { get; set; }
}

using System;
using System.Collections.Generic;

namespace DataMgmtModule.Domain.Entities;

public partial class RecipesLog
{
    public int? RecipeId { get; set; }

    public string? ProductName { get; set; }

    public string? Comments { get; set; }

    public int? ProjectId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? AdditiveId { get; set; }

    public int? MainPolymerId { get; set; }

    public string? DeletedBy { get; set; }

    public DateTime? DeletedDate { get; set; }

    public int LogId { get; set; }
}

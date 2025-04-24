using System;
using System.Collections.Generic;

namespace DataMgmtModule.Domain.Entities;

public partial class CompoundingComponent
{
    public int Id { get; set; }

    public int? RecipeId { get; set; }

    public int? CompoundingId { get; set; }

    public decimal? Share { get; set; }

    public bool? Mf { get; set; }

    public bool? _2ndF { get; set; }

    public bool? Sf { get; set; }

    public bool? A { get; set; }

    public bool? B { get; set; }

    public bool? C { get; set; }

    public bool? D { get; set; }

    public bool? E { get; set; }

    public bool? F { get; set; }

    public int ComponentId { get; set; }

    public DateTime? CreatedDate { get; set; }
    public int? CreatedBy { get; set; }
    public int? ModifiedBy { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public virtual Component Component { get; set; } = null!;

    public virtual CompoundingDatum? Compounding { get; set; }

    public virtual Recipe? Recipe { get; set; }

}

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DataMgmtModule.Domain.Entities;

public partial class Additive:Common
{
    public int Id { get; set; }

    public string AdditiveName { get; set; } = null!;
    public bool isDelete { get; set; }
    [JsonIgnore]
    public virtual ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();
}

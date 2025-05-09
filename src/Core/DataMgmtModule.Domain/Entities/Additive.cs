﻿using System;
using System.Collections.Generic;

namespace DataMgmtModule.Domain.Entities;

public partial class Additive:Common
{
    public int Id { get; set; }

    public string AdditiveName { get; set; } = null!;

    public virtual ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();
}

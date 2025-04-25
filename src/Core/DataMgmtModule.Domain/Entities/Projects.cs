using System;
using System.Collections.Generic;
using DataMgmtModule.Domain.Enum.ProjectsEnums;

namespace DataMgmtModule.Domain.Entities;

public partial class Projects:Common
{
    public int ProjectId { get; set; }

    public string? ProjectName { get; set; }

    public ProjectTypes? ProjectType { get; set; }

    public Areas? Area { get; set; }

    public Status? Status { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public bool IsDelete { get; set; }

    public string? Project_Description { get; set; }

    public Priorities? Priority { get; set; }

    public virtual ICollection<InjectionMolding> InjectionMoldings { get; set; } = new List<InjectionMolding>();

    public virtual ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();
}

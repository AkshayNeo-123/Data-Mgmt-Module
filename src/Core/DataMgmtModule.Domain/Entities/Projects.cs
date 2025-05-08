using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DataMgmtModule.Domain.Entities;

public partial class Projects:Common
{
    [Key]
    public int ProjectId { get; set; }

    public string? ProjectName { get; set; }
    public string? ProjectNumber { get; set; }

    public int? ProjectTypeId { get; set; }
    [ForeignKey("ProjectTypeId")]
    public ProjectTypes ProjectTypes { get; set; }

    public int? AreaId { get; set; }
    [ForeignKey("AreaId")]
    public Areas Areas { get; set; }

    public int? StatusId { get; set; }
    [ForeignKey("StatusId")]
    public Status Status { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public bool IsDelete { get; set; }

    public string? Project_Description { get; set; }

    public int? PriorityId { get; set; }
    [ForeignKey("PriorityId")]
    public Priorities Priorities { get; set; }

    public virtual ICollection<InjectionMolding> InjectionMoldings { get; set; } = new List<InjectionMolding>();
    //[JsonIgnore]
    public virtual ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();
}

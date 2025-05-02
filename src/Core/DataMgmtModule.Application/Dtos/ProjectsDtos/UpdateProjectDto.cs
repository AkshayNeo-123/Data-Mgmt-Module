using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using DataMgmtModule.Domain.Entities;

namespace DataMgmtModule.Application.Dtos.ProjectsDtos
{
    public class UpdateProjectDto
    {

        [Required]
        public string ProjectName { get; set; }
        //[Required]
        public int? ProjectTypeId { get; set; }
        //public ProjectTypes ProjectTypes { get; set; }
        //[Required]
        public int? AreaId { get; set; }
        //public Areas Areas { get; set; }
        public int? PriorityId { get; set; }
        [Required]
        public int? StatusId { get; set; }
        [Required]
        public string? Project_Description { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        //[Required]
        //public string ProjectName { get; set; }

        //public int? ProjectTypeId { get; set; }

        //public int? AreaId { get; set; }
        //[Required]
        //public int? StatusId { get; set; }

        //public int? PriorityId { get; set; }
        //[Required]
        //public string Project_Description { get; set; }

        //public DateTime? StartDate { get; set; }

        //public DateTime? EndDate { get; set; }
    }
}

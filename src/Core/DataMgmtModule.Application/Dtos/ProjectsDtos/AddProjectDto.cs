using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using DataMgmtModule.Domain.Entities;

namespace DataMgmtModule.Application.Dtos.ProjectsDtos
{
    public class AddProjectDto
    {

        
        [Required]
        public string ProjectName { get; set; }
        [Required]
        public string? ProjectNumber { get; set; }
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
        [JsonPropertyName("projectDescription")]
        public string? Project_Description { get; set; }

        public DateOnly? StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
        public int? CreatedBy { get; set; }




    }
}

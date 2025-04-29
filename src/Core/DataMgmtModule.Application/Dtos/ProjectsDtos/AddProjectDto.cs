using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Domain.Enum.ProjectsEnums;
using System.Text.Json.Serialization;

namespace DataMgmtModule.Application.Dtos.ProjectsDtos
{
    public class AddProjectDto
    {

        
        [Required]
        public string? ProjectName { get; set; }
        [Required]
        public ProjectTypes? ProjectType { get; set; }
        [Required]
        public Areas? Area { get; set; }
        [Required]
        public Priorities? Priority { get; set; }
        [Required]
        [JsonPropertyName("projectDescription")]
        public string? Project_Description { get; set; }
        [Required]
        public DateTime? StartDate { get; set; }
        //[Required]
        public DateTime? EndDate { get; set; }



    }
}

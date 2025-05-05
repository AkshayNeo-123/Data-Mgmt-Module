using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Domain.Entities;

namespace DataMgmtModule.Application.Dtos.ProjectsDtos
{
    public class GetAllProjectsDto
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string? ProjectNumber { get; set; }
        [Required]
        public int ProjectTypeId { get; set; }
        public ProjectTypes ProjectTypes { get; set; }
        [Required]
        public int AreaId { get; set; }
        public Areas Areas { get; set; }
        [Required]
        public int? StatusId { get; set; }
        public Status Status { get; set; }            

        public int? PriorityId { get; set; }
        public Priorities Priorities { get; set; }
        public string? Project_Description { get; set; }
        [Required]
        public DateOnly? StartDate { get; set; }
        [Required]
        public DateOnly? EndDate { get; set; }
        [Required]
        //public byte IsDelete { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}

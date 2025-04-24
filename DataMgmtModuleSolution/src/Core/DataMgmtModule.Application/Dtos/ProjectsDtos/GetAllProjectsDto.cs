using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Domain.Enum.ProjectsEnums;

namespace DataMgmtModule.Application.Dtos.ProjectsDtos
{
    public class GetAllProjectsDto
    {
        public string ProjectName { get; set; }
        [Required]
        public ProjectTypes ProjectType { get; set; }
        [Required]
        public Areas Area { get; set; }
        [Required]
        public Status Status { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public byte IsDelete { get; set; }

        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMgmtModule.Application.Dtos
{
    public class CompoundingDataDTO
    {
        public int ReceipeId { get; set; }
        public int ParameterSet { get; set; }
        public DateOnly? Date { get; set; }
       
        public string? Notes { get; set; }
      
        public int? Repetation { get; set; }
  
        public decimal? Temperature { get; set; }
       
        public decimal? Duration { get; set; }
      
        public decimal? ResidualM { get; set; }
        
        public bool? NotMeasured { get; set; }

        public bool? PretreatmentNone { get; set; }
        public bool? PretreatmentDrying { get; set; }

    }
}

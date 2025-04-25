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
        //public int ReceipeId { get; set; }
        public int ParameterSet { get; set; }
        [Required]

        public DateOnly Date { get; set; }
        [Required]

        public string Notes { get; set; }
        [Required]

        public int Repetation { get; set; }
        [Required]
        public int Pretreatment { get; set; }
        public decimal Temperature { get; set; }
        [Required]

        public TimeSpan Duration { get; set; }

        [Required]
        public decimal ResidualM { get; set; }
        [Required]
        public int NotMeasured { get; set; }

    }
}

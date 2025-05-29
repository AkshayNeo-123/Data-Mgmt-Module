using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMgmtModule.Domain.Entities
{
   public class TemperatureProperty : CommonTest
    {
        [Key]
        public int Id { get; set; }
        public int TestId { get; set; }

        public decimal? TempHdtA { get; set; }
        public decimal? TempHdtB { get; set; }
        public decimal? MeltingTemp { get; set; }

        public decimal? CoefficientsParallel { get; set; }
        public decimal? CoefficientsTransverse { get; set; }
        public bool IsDelete { get; set; } = false;
        public Test Test { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMgmtModule.Domain.Entities
{
    public class FlammabilityProperties :CommonTest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("Test")]
        public int TestId { get; set; }
        public Test Test { get; set; }

        public decimal? BurningRateWallThickness { get; set; }
        public decimal? GWFI { get; set; }
        public decimal? GWFT { get; set; }
        public decimal? BurningRateThickness1 { get; set; }
        public decimal? BurningRateThickness2 { get; set; }


        public bool IsDelete { get; set; }
    }
}

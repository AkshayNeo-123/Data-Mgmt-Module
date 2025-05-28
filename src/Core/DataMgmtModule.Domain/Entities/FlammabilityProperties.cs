using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMgmtModule.Domain.Entities
{
    public class FlammabilityProperties
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Test")]
        public int Testid { get; set; }
        public Test Test { get; set; }  

        public int? BurningRateWallThickness { get; set; }

        public int? GWFI { get; set; }

        public int? GWFT { get; set; }

        public int? BurningRateThickness1 { get; set; }

        public int? BurningRateThickness2 { get; set; }

        public int? ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public int? DeletedBy { get; set; }

        public DateTime? DeletedDate { get; set; }

        public bool IsDelete { get; set; }
    }
}

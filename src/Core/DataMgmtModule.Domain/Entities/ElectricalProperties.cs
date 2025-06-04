using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMgmtModule.Domain.Entities
{
    public class ElectricalProperties:CommonTest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int TestId { get; set; }

        public Test Test { get; set; }

        public decimal? VolumeResistivity1 { get; set; }

        public decimal? VolumeResistivity2 { get; set; }

        public decimal? SurfaceResistivity { get; set; }

        public decimal? ComparativeTracking { get; set; }

        public bool IsDelete { get; set; }
    }

}

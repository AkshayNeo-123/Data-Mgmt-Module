using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMgmtModule.Domain.Entities
{
    public class ElectricalProperties
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int Testid { get; set; }

        public int? VolumeResistivity1 { get; set; }

        public int? VolumeResistivity2 { get; set; }

        public int? SurfaceResistivity { get; set; }

        public int? ComparativeTracking { get; set; }
        public bool IsDelete { get; set; }
    }

}

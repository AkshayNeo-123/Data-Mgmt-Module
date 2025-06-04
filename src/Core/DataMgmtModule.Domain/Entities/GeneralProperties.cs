using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMgmtModule.Domain.Entities
{
    public class GeneralProperties:CommonTest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int TestId { get; set; }
        public Test Test { get; set; }
        public decimal? Density { get; set; }

        public decimal? HumidityAbsorption { get; set; }

        public decimal? MoldingShrinkageFlow { get; set; }

        public decimal? MoldingShrinkageTransverse { get; set; }

        public decimal? MFR { get; set; }

        public decimal? MVR { get; set; }

        public bool IsDelete { get; set; }
    }
}

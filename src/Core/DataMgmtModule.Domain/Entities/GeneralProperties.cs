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
        public int? Density { get; set; }

        public int? HumidityAbsorption { get; set; }

        public int? MoldingShrinkageFlow { get; set; }

        public int? MoldingShrinkageTransverse { get; set; }

        public int? MFR { get; set; }

        public int? MVR { get; set; }
        public bool IsDelete { get; set; }
    }
}

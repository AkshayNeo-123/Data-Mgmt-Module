using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMgmtModule.Application.Dtos
{
    public class UpdateRecipeComponentDto
    {
        public int ComponentId { get; set; }
        public decimal? WtPercent { get; set; }
        public decimal? ValPercent { get; set; }
        public decimal? Density { get; set; }
        public bool? MP { get; set; }
        public bool? MF { get; set; }
    }
}

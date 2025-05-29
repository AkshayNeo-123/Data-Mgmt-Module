using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMgmtModule.Application.Dtos.TestDtos
{
    public class AddDto
    {
        public int RecipeNumber { get; set; }
        public string Comment { get; set; }
        public bool IsPublish { get; set; }

    }

    public class TemperaturePropertyDto
    {
        public decimal? TempHdtA { get; set; }
        public decimal? TempHdtB { get; set; }
        public decimal? MeltingTemp { get; set; }
        public decimal? CoefficientsParallel { get; set; }
        public decimal? CoefficientsTransverse { get; set; }
    }

    public class FlammabilityPropertyDto
    {
        public int? BurningRateWallThickness { get; set; }
        public int? GWFI { get; set; }
        public int? GWFT { get; set; }
        public int? BurningRateThickness1 { get; set; }
        public int? BurningRateThickness2 { get; set; }
    }


}

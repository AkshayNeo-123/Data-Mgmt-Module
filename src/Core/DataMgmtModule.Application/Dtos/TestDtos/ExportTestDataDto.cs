using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMgmtModule.Application.Dtos.TestDtos
{
    public class ExportTestDataDto
    {
        public int TestId { get; set; }

        public ExportAddDto Test { get; set; }
        public MechanicalPropertyDto? MechanicalProperty { get; set; }

        public TemperaturePropertyDto? TemperatureProperty { get; set; }
        public FlammabilityPropertyDto? FlammabilityProperty { get; set; }
        public GeneralPropertyDto? GeneralProperty { get; set; }
        public ElectricalPropertyDto? ElectricalProperty { get; set; }

        public PropertiesDto? Properties { get; set; }
    }
}

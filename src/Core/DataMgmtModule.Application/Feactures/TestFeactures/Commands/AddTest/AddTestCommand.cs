using DataMgmtModule.Application.Dtos.TestDtos;
using MediatR;
using System.Collections.Generic;

namespace DataMgmtModule.Application.Feactures.TestFeactures.Commands.AddTest
{
    public class AddTestCommand : IRequest<int>
    {
        public AddDto Test { get; set; }
        public MechanicalPropertyDto? MechanicalProperty { get; set; }

        public TemperaturePropertyDto? TemperatureProperty { get; set; }
        public FlammabilityPropertyDto? FlammabilityProperty { get; set; }
        public GeneralPropertyDto? GeneralProperty { get; set; }
        public ElectricalPropertyDto? ElectricalProperty { get; set; }

        public PropertiesDto? Properties { get; set; }

    }
}

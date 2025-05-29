using DataMgmtModule.Application.Dtos.TestDtos;
using MediatR;
using System.Collections.Generic;

namespace DataMgmtModule.Application.Feactures.TestFeactures.Commands.AddTest
{
    public class AddTestCommand : IRequest<int>
    {
        public AddDto Test { get; set; }
        public List<TemperaturePropertyDto> TemperatureProperties { get; set; }
        public List<FlammabilityPropertyDto> FlammabilityProperties { get; set; }
    }
}

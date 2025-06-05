using System.Text.Json.Serialization;
using DataMgmtModule.Application.Dtos.TestDtos;
using MediatR;

namespace DataMgmtModule.Application.Features.TestFeatures.Commands.UpdateTest
{
    public class UpdateTestCommand : IRequest<int>
    {
        [JsonIgnore]
        public int TestId { get; set; } 

        public AddDto Test { get; set; }
        public TemperaturePropertyDto?   TemperatureProperty { get; set; }
        public FlammabilityPropertyDto? FlammabilityProperty { get; set; }
        public MechanicalPropertyDto? MechanicalProperty { get; set; }
        public GeneralPropertyDto? GeneralProperty { get; set; }
        public ElectricalPropertyDto? ElectricalProperty { get; set; }
        public PropertiesDto? Properties { get; set; }
    }
}

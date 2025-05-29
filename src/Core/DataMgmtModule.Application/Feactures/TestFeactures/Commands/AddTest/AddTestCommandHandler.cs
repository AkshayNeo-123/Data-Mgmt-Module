using AutoMapper;
using DataMgmtModule.Application.Feactures.TestFeactures.Commands.AddTest;
using DataMgmtModule.Application.Interface.Persistence;
using DataMgmtModule.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DataMgmtModule.Application.Features.TestFeatures.Commands.AddTest
{
    public class AddTestCommandHandler : IRequestHandler<AddTestCommand, int>
    {
        private readonly ITestRepository _repository;
        private readonly IMapper _mapper;

        public AddTestCommandHandler(ITestRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> Handle(AddTestCommand request, CancellationToken cancellationToken)
        {
            var test = _mapper.Map<Test>(request.Test);
            test.IsDelete = false;

            // One-to-one property assignments
            if (request.TemperatureProperty != null)
            {
                test.TemperatureProperty = _mapper.Map<TemperatureProperty>(request.TemperatureProperty);
            }

            if (request.FlammabilityProperty != null)
            {
                test.FlammabilityProperty = _mapper.Map<FlammabilityProperties>(request.FlammabilityProperty);
            }

            if (request.MechanicalProperty != null)
            {
                test.MechanicalProperty = _mapper.Map<MechanicalProperty>(request.MechanicalProperty);
            }

            if (request.GeneralProperty != null)
            {
                test.GeneralProperty = _mapper.Map<GeneralProperties>(request.GeneralProperty);
            }

            if (request.ElectricalProperty != null)
            {
                test.ElectricalProperty = _mapper.Map<ElectricalProperties>(request.ElectricalProperty);
            }

            if (request.Properties != null)
            {
                test.Properties = _mapper.Map<Properties>(request.Properties);
            }

            var newTestId = await _repository.AddTest(test);
            return newTestId;
        }
    }

}

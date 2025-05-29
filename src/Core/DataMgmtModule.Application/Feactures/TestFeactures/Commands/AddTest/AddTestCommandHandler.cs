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
        readonly ITestRepository _repository;
        readonly IMapper _mapper;
        public AddTestCommandHandler(ITestRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> Handle(AddTestCommand request, CancellationToken cancellationToken)
        {
            var test = _mapper.Map<Test>(request.Test);
            test.IsDelete = false;

            // Map related collections
            test.TemperatureProperties = _mapper.Map<List<TemperatureProperty>>(request.TemperatureProperties ?? new());
            test.FlammabilityProperties = _mapper.Map<List<FlammabilityProperties>>(request.FlammabilityProperties ?? new());

            var newTestId = await _repository.AddTest(test);

            return newTestId;
        }
    }
}

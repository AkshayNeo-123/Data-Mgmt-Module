using AutoMapper;
using DataMgmtModule.Application.Feactures.TestFeactures.Commands.AddTest;
using DataMgmtModule.Application.Interface.Persistence;
using DataMgmtModule.Domain.Entities;
using MediatR;
using System;
using System.Reflection;
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

            bool IsAllDefault<T>(T obj) => obj == null || typeof(T).GetProperties()
                .All(p => Equals(p.GetValue(obj), p.PropertyType.IsValueType ? Activator.CreateInstance(p.PropertyType) : null));

            if (!IsAllDefault(request.TemperatureProperty))
                test.TemperatureProperty = _mapper.Map<TemperatureProperty>(request.TemperatureProperty);

            if (!IsAllDefault(request.FlammabilityProperty))
                test.FlammabilityProperty = _mapper.Map<FlammabilityProperties>(request.FlammabilityProperty);

            if (!IsAllDefault(request.MechanicalProperty))
                test.MechanicalProperty = _mapper.Map<MechanicalProperty>(request.MechanicalProperty);

            if (!IsAllDefault(request.GeneralProperty))
                test.GeneralProperty = _mapper.Map<GeneralProperties>(request.GeneralProperty);

            if (!IsAllDefault(request.ElectricalProperty))
                test.ElectricalProperty = _mapper.Map<ElectricalProperties>(request.ElectricalProperty);

            if (!IsAllDefault(request.Properties))
                test.Properties = _mapper.Map<Properties>(request.Properties);

            return await _repository.AddTest(test);
        }


    }
}

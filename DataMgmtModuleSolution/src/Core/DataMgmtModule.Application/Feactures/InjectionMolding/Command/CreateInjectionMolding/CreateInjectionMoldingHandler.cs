using AutoMapper;
using DataMgmtModule.Application.Features.InjectionMoldings.Commands.CreateInjectionMolding;
using DataMgmtModule.Application.Interface.Persistence;
using DataMgmtModule.Domain.Entities;
using MediatR;
using DomainInjectionMolding = DataMgmtModule.Domain.Entities.InjectionMolding;

namespace DataMgmtModule.Application.Features.InjectionMoldings.Commands.CreateInjectionMolding
{
    public class CreateInjectionMoldingHandler : IRequestHandler<CreateInjectionMoldingCommand, int>
    {
        private readonly IInjectionMoldingRepository _repository;
        private readonly IMapper _mapper;

        public CreateInjectionMoldingHandler(IInjectionMoldingRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateInjectionMoldingCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<DomainInjectionMolding>(request.InjectionMoldingDto);
            var created = await _repository.AddAsync(entity);
            return created.Id;
        }
    }
}

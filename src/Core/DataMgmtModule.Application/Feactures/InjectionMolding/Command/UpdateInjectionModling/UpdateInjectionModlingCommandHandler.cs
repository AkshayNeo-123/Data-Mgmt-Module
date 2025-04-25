using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataMgmtModule.Application.Interface.Persistence;
using MediatR;
using DomainInjectionMolding = DataMgmtModule.Domain.Entities.InjectionMolding;

namespace DataMgmtModule.Application.Feactures.InjectionMolding.Command.UpdateInjectionModling
{
    public class UpdateInjectionModlingCommandHandler : IRequestHandler<UpdateInjectionModlingCommand, int>
    {
        private readonly IInjectionMoldingRepository _repository;
        private readonly IMapper _mapper;

        public UpdateInjectionModlingCommandHandler(IInjectionMoldingRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<int> Handle(UpdateInjectionModlingCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<DomainInjectionMolding>(request.injectionMolding);
            return await _repository.UpdateInjectionMolding(request.id,entity,request.userId);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataMgmtModule.Application.Dtos.InjectionMolding;
using DataMgmtModule.Application.Dtos.Materials;
using DataMgmtModule.Application.Feactures.Materials.Query.GetMaterialById;
using DataMgmtModule.Application.Interface.Persistence;
using MediatR;

namespace DataMgmtModule.Application.Feactures.InjectionMolding.Query.InjectionMoldingById
{
    public class InjectionMoldingByIdQueryCommand : IRequestHandler<InjectionMoldingByIdQuery, UpdateInjectionMoldingDto>
    {
        private readonly IInjectionMoldingRepository _repository;
        private readonly IMapper _mapper;

        public InjectionMoldingByIdQueryCommand(IInjectionMoldingRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<UpdateInjectionMoldingDto> Handle(InjectionMoldingByIdQuery request, CancellationToken cancellationToken)
        {
            var injection = await _repository.GetInjectionMoldingbyId(request.Id);
            return _mapper.Map<UpdateInjectionMoldingDto>(injection); throw new NotImplementedException();
        }
    }
}

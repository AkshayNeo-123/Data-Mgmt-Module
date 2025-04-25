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

namespace DataMgmtModule.Application.Feactures.InjectionMolding.Query.GetByIdInjectionMolding
{
    public class GetByIdInjectionMoldingQueryCommand : IRequestHandler<GetByIdInjectionMoldingQuery, List<InjectionMoldingDto>>
    {
        private readonly IInjectionMoldingRepository _repository;
        private readonly IMapper _mapper;

        public GetByIdInjectionMoldingQueryCommand(IInjectionMoldingRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<InjectionMoldingDto>> Handle(GetByIdInjectionMoldingQuery request, CancellationToken cancellationToken)
        {
            var injection = await _repository.GetByIdInjectionMolding(request.Id);
            return _mapper.Map<List<InjectionMoldingDto>>(injection); throw new NotImplementedException();
        }
    }
}

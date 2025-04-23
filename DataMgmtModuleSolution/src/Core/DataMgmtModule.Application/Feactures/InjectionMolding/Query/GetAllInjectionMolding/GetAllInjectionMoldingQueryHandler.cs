using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataMgmtModule.Application.Dtos.InjectionMolding;
using DataMgmtModule.Application.Interface.Persistence;
using MediatR;

namespace DataMgmtModule.Application.Feactures.InjectionMolding.Query.GetAllInjectionMolding
{
   public class GetAllInjectionMoldingQueryHandler : IRequestHandler<GetAllInjectionMoldingQuery, IEnumerable<InjectionMoldingDto>>
    {
        private readonly IInjectionMoldingRepository _repository;
        private readonly IMapper _mapper;

        public GetAllInjectionMoldingQueryHandler(IInjectionMoldingRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<InjectionMoldingDto>> Handle(GetAllInjectionMoldingQuery request, CancellationToken cancellationToken)
        {
            var injectionMoldings = await _repository.GetAllInjectionMolding();
            return _mapper.Map<IEnumerable<InjectionMoldingDto>>(injectionMoldings);
        }
    }
}

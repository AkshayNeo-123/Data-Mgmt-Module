using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Application.Interface.Persistence;
using DataMgmtModule.Domain.Entities;
using MediatR;

namespace DataMgmtModule.Application.Feactures.CompoundingComponentsDatas.Query.GetCompoundingComponents
{
    public class GetCompoundingComponentsQueryHandler : IRequestHandler<GetCompoundingComponentsQuery, Domain.Entities.CompoundingComponent>
    {
        private readonly ICompoundingComponentsRepository _compoundingComponentsRepository;

        public GetCompoundingComponentsQueryHandler(ICompoundingComponentsRepository compoundingComponentsRepository)
        {
            _compoundingComponentsRepository = compoundingComponentsRepository; 
        }
        public Task<Domain.Entities.CompoundingComponent> Handle(GetCompoundingComponentsQuery request, CancellationToken cancellationToken)
        {
            var getData = _compoundingComponentsRepository.GetCompoundingComponentsAsync(request.Id);
            return getData;
        }
    }
}

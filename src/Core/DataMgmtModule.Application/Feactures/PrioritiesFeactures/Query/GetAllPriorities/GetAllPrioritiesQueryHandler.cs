using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Application.Interface.Persistence;
using DataMgmtModule.Domain.Entities;
using MediatR;

namespace DataMgmtModule.Application.Feactures.ProjectTypeFeactures.Query.GetAllPriorities
{
    public class GetAllPrioritiesQueryHandler : IRequestHandler<GetAllPrioritiesQuery, IEnumerable<Priorities>>
    {
        readonly IPrioritiesRepository _repository;
        public GetAllPrioritiesQueryHandler(IPrioritiesRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<Priorities>> Handle(GetAllPrioritiesQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllPriorities();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Application.Interface.Persistence;
using DataMgmtModule.Domain.Entities;
using MediatR;

namespace DataMgmtModule.Application.Feactures.ProjectTypeFeactures.Query.GetAllAreas
{
    public class GetAllAreasQueryHandler : IRequestHandler<GetAllAreasQuery, IEnumerable<Areas>>
    {
        readonly IAreasRepository _repository;
        public GetAllAreasQueryHandler(IAreasRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<Areas>> Handle(GetAllAreasQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAreas();
        }
    }
}

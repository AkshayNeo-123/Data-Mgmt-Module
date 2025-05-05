using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Application.Interface.Persistence;
using DataMgmtModule.Domain.Entities;
using MediatR;

namespace DataMgmtModule.Application.Feactures.ProjectTypeFeactures.Query.GetAllProjectTypes
{
    public class GetAllProjectTypesQueryHandler : IRequestHandler<GetAllProjectTypesQuery, IEnumerable<ProjectTypes>>
    {
        readonly IProjectTypeRepository _repository;
        public GetAllProjectTypesQueryHandler(IProjectTypeRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<ProjectTypes>> Handle(GetAllProjectTypesQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllProjectTypes();
        }
    }
}

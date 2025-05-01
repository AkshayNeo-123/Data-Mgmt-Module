using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Application.Interface.Persistence;
using DataMgmtModule.Domain.Entities;
using MediatR;

namespace DataMgmtModule.Application.Feactures.ProjectTypeFeactures.Query.GetAllStatus
{
    public class GetAllStatusQueryHandler : IRequestHandler<GetAllStatusQuery, IEnumerable<Status>>
    {
        readonly IStatusRepository _repository;
        public GetAllStatusQueryHandler(IStatusRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<Status>> Handle(GetAllStatusQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllStatus();
        }
    }
}

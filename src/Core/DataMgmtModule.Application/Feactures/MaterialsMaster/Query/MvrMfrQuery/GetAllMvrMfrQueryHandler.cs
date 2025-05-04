using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Application.Interface.Persistence;
using DataMgmtModule.Domain.Entities;
using MediatR;

namespace DataMgmtModule.Application.Feactures.MaterialsMaster.Query.MvrMfrQuery
{
    public class GetAllMvrMfrQueryHandler : IRequestHandler<GetAllMvrMfrQuery, IEnumerable<MvrMfr>>
    {
        private readonly IMaterialMasterRepository _repository;

        public GetAllMvrMfrQueryHandler(IMaterialMasterRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<MvrMfr>> Handle(GetAllMvrMfrQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllMvrMfr();
        }
    }
}

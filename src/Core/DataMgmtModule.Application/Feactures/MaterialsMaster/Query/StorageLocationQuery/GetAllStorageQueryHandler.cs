using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Application.Interface.Persistence;
using DataMgmtModule.Domain.Entities;
using MediatR;

namespace DataMgmtModule.Application.Feactures.MaterialsMaster.Query.StorageLocationQuery
{
    class GetAllStorageQueryHandler :IRequestHandler<GetAllStorageQuery, IEnumerable<StorageLocation>>
    {
        private readonly IMaterialMasterRepository _repository;

        public GetAllStorageQueryHandler(IMaterialMasterRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<StorageLocation>> Handle(GetAllStorageQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllStorage();
        }
    }
}

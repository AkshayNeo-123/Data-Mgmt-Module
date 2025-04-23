using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Application.Interface.Persistence;
using MediatR;

namespace DataMgmtModule.Application.Feactures.CompoundingDatas.Command.DeleteCompoundingData
{
    public class DeleteCompoundingDataCommandHandler : IRequestHandler<DeleteCompoundingDataCommand, int>
    {
        private readonly ICompoundingData _compoundingData;
        public DeleteCompoundingDataCommandHandler(ICompoundingData compoundingData)
        {
            _compoundingData = compoundingData;
        }
        public Task<int> Handle(DeleteCompoundingDataCommand request, CancellationToken cancellationToken)
        {
            var deletData = _compoundingData.DeleteCompoundingDataAsync(request.id);
            return deletData;
        }
    }
}

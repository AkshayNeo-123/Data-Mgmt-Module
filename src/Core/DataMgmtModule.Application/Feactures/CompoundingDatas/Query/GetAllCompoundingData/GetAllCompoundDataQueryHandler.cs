using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Application.Interface.Persistence;
using DataMgmtModule.Domain.Entities;
using MediatR;

namespace DataMgmtModule.Application.Feactures.CompoundingDatas.Query.GetAllCompoundingData {
    public class GetAllCompoundDataQueryHandler : IRequestHandler<GetAllCompoundDataQuery, IEnumerable<CompoundingDatum>>
    {
        private readonly ICompoundingData _compoundingData;
        public GetAllCompoundDataQueryHandler(ICompoundingData compoundingData)
        {
            _compoundingData = compoundingData;
        }
        public Task<IEnumerable<CompoundingDatum>> Handle(GetAllCompoundDataQuery request, CancellationToken cancellationToken)
        {

            var getCompoundingData = _compoundingData.GetAllCompoundingDatumAsync();
            return getCompoundingData;
        }
    }
}

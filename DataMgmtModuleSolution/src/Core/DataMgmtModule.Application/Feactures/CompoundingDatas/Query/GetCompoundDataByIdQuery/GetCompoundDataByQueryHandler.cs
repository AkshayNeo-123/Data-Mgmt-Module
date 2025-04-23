using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Application.Interface.Persistence;
using DataMgmtModule.Domain.Entities;
using MediatR;

namespace DataMgmtModule.Application.Feactures.CompoundingDatas.Query.GetCompoundDataByIdQuery
{
    public class GetCompoundDataByQueryHandler : IRequestHandler<GetCompoundDataByQuery, CompoundingDatum>
    {
        private readonly ICompoundingData _compoundingData;
        public GetCompoundDataByQueryHandler(ICompoundingData compoundingData)
        {
            _compoundingData = compoundingData;   
        }

        public Task<CompoundingDatum> Handle(GetCompoundDataByQuery request, CancellationToken cancellationToken)
        {
            var getData = _compoundingData.GetCompoundingDataAsync(request.Id);
            return getData;
        }
        //public Task<CompoundingData> Handle(GetCompoundDataByQuery request, CancellationToken cancellationToken)
        //{
        //    var getData=_
        //}
    }
}

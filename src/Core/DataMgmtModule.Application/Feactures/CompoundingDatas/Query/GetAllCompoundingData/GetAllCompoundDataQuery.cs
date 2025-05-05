using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Domain.Entities;
using MediatR;

namespace DataMgmtModule.Application.Feactures.CompoundingDatas.Query.GetAllCompoundingData
{
    public record GetAllCompoundDataQuery : IRequest<IEnumerable<CompoundingDatum>>
    {
    }
}

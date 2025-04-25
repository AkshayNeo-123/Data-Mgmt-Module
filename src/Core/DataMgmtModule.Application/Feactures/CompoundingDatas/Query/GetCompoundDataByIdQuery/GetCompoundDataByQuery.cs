using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Domain.Entities;
using MediatR;

namespace DataMgmtModule.Application.Feactures.CompoundingDatas.Query.GetCompoundDataByIdQuery
{
    public record GetCompoundDataByQuery(int Id):IRequest<CompoundingDatum>
    {
    }
}

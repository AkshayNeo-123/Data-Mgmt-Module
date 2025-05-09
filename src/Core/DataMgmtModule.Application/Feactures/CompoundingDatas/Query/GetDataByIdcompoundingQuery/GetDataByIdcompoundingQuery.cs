using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Application.Dtos.CommonDtos;
using DataMgmtModule.Domain.Entities;
using MediatR;

namespace DataMgmtModule.Application.Feactures.CompoundingDatas.Query.GetDataByIdcompoundingQuery
{
    public record GetDataByIdcompoundingQuery(int Id):IRequest<CompoundingDataAndComponents>
    {
    }
}

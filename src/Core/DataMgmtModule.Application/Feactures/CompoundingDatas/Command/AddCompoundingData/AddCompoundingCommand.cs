using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Application.Dtos;
using MediatR;
using DataMgmtModule.Domain.Entities;
using DataMgmtModule.Application.Dtos.CommonDtos;

namespace DataMgmtModule.Application.Feactures.CompoundingDatas.Command.AddCompoundingData
{
    public record AddCompoundingCommand(CompoundingDataAndComponents compoundingDataDTO,int? userId) : IRequest<int>
    {
    }
}

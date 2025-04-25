using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Application.Dtos;
using DataMgmtModule.Application.Dtos.CommonDtos;
using MediatR;

namespace DataMgmtModule.Application.Feactures.CompoundingDatas.Command.UpdateCompoundingData
{
    public record UpdateCompoundingCommand(int id, CompoundingDataDTO compoundingDataDTO, int? userId) :IRequest<int>
    {
    }
}

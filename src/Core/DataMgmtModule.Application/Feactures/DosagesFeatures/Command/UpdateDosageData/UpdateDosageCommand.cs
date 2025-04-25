using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Application.Dtos.CommonDtos;
using MediatR;

namespace DataMgmtModule.Application.Feactures.DosagesFeatures.Command.UpdateDosageData
{
    public record UpdateDosageCommand(int id,CompoundingDataAndComponents compoundingDataAndComponents,int? userId):IRequest<int>
    {
    }
}

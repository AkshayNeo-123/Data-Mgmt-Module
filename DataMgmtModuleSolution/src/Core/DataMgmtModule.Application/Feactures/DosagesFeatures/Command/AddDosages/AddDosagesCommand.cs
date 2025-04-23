using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Application.Dtos.CommonDtos;
using DataMgmtModule.Application.Dtos.Dosage;
using MediatR;

namespace DataMgmtModule.Application.Feactures.DosagesFeatures.Command.AddDosages
{
    public record AddDosagesCommand(int id,CompoundingDataAndComponents compoundingDataAndComponents):IRequest<int>
    {
    }
}

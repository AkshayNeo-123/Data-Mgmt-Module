using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Application.Dtos.CommonDtos;
using MediatR;

namespace DataMgmtModule.Application.Feactures.CompoundingComponentsDates.Command.AddCompoundingComponents
{
    public record AddCompoundingComponentsCommand(int Id, CompoundingDataAndComponents compoundingDataAndComponents) : IRequest<int>
    {
    }
}

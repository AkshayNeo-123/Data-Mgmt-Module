using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Application.Dtos.CommonDtos;
using MediatR;

namespace DataMgmtModule.Application.Feactures.CompoundingComponentsDatas.Command.UpdateCompoundingComponentsData
{
    public record UpdateCompoundingComponentsCommad(int id,CompoundingDataAndComponents compoundingDataAndComponents,int? userId):IRequest<int>
    {
    }
}

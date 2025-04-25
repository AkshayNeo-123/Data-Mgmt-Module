using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Application.Dtos.InjectionMolding;
using DataMgmtModule.Application.Dtos.Materials;
using MediatR;

namespace DataMgmtModule.Application.Feactures.InjectionMolding.Query.GetAllInjectionMolding
{
    public record GetAllInjectionMoldingQuery : IRequest<IEnumerable<InjectionMoldingDto>> { }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Application.Dtos.InjectionMolding;
using DataMgmtModule.InjectionMoldingInjectionMolding.InjectionMolding;
using MediatR;

namespace DataMgmtModule.Application.Feactures.InjectionMolding.Command.UpdateInjectionModling
{
    public record UpdateInjectionModlingCommand(int id, UpdateInjectionMoldingDto injectionMolding,int? userId) : IRequest<int>
    {
        
    }
}

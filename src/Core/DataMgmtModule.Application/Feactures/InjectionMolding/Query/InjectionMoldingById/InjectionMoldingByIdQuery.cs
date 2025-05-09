using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Application.Dtos.InjectionMolding;
using MediatR;

namespace DataMgmtModule.Application.Feactures.InjectionMolding.Query.InjectionMoldingById
{
    public class InjectionMoldingByIdQuery :IRequest <UpdateInjectionMoldingDto>
    {
        public int Id { get; set; }

        public InjectionMoldingByIdQuery(int id)
        {
            Id = id;
        }
    }
}

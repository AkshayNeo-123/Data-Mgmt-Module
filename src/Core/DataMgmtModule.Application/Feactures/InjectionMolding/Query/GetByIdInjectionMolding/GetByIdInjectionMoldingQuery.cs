using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Application.Dtos.InjectionMolding;
using MediatR;

namespace DataMgmtModule.Application.Feactures.InjectionMolding.Query.GetByIdInjectionMolding
{
    public class GetByIdInjectionMoldingQuery :IRequest <List<InjectionMoldingDto>>
    {
        public int Id { get; set; }

        public GetByIdInjectionMoldingQuery(int id)
        {
            Id = id;
        }
    }
}

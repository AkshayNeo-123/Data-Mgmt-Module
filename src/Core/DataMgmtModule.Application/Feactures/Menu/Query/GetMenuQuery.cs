using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Application.Dtos.Menu;
using DataMgmtModule.Domain.Entities;
using MediatR;

namespace DataMgmtModule.Application.Feactures.Menu.Query
{
    public record GetMenuQuery:IRequest<IEnumerable<MenuWithChildCountDto>>
    {

    }
}

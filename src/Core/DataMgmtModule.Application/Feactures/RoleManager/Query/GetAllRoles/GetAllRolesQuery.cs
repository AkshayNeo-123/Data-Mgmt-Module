using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Application.Dtos.RoleManagerDto;
using DataMgmtModule.Domain.Entities;
using MediatR;

namespace DataMgmtModule.Application.Feactures.RoleManager.Query.GetAllRoles
{
    public record GetAllRolesQuery:IRequest<IEnumerable<GetRoleDto>>
    {
    }
}

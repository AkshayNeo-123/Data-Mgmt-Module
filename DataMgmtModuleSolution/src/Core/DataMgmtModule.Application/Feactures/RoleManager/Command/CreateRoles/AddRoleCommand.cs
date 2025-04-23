using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Domain.Entities;
using MediatR;

namespace DataMgmtModule.Application.Feactures.RoleManager.Command.CreateRoles
{
    public record  AddRoleCommand(AddRole addRole):IRequest<Roles>
    {
     
    }
}

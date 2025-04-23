using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Domain.Entities;
using MediatR;

namespace DataMgmtModule.Application.Feactures.RoleManager.Query.GetRolesById
{
    public record GetRolesbyIdQuery(int Id):IRequest<Roles>
    {
    }
}

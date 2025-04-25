using MediatR;
using DataMgmtModule.Application.Features.RolePermissions.DTOs;
using System.Collections.Generic;

namespace DataMgmtModule.Application.Features.RolePermissions.Queries.GetAllRolePermissions
{
    public class GetAllRolePermissionsQuery : IRequest<List<RolePermissionDto>>
    {
    }
}

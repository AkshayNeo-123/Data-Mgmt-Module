using MediatR;
using DataMgmtModule.Application.Features.RolePermissions.DTOs;

namespace DataMgmtModule.Application.Features.RolePermissions.Commands.CreateRolePermission
{
    public class CreateRolePermissionCommand : IRequest<RolePermissionDto>
    {
        public RolePermissionDto RolePermission { get; set; }

        public CreateRolePermissionCommand(RolePermissionDto rolePermission)
        {
            RolePermission = rolePermission;
        }
    }
}

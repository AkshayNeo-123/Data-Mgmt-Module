using MediatR;
using DataMgmtModule.Application.Features.RolePermissions.DTOs;

namespace DataMgmtModule.Application.Features.RolePermissions.Commands.UpdateRolePermission
{
    public class UpdateRolePermissionCommand : IRequest<RolePermissionDto>
    {
        public int Id { get; set; } 
        public RolePermissionDto RolePermission { get; set; }

        public UpdateRolePermissionCommand(int id, RolePermissionDto rolePermission)
        {
            Id = id;
            RolePermission = rolePermission;
        }
    }
}

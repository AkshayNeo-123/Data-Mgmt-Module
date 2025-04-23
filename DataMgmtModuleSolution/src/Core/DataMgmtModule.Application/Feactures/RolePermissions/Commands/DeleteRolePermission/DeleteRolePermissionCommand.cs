using MediatR;

namespace DataMgmtModule.Application.Features.RolePermissions.Commands.DeleteRolePermission
{
    public class DeleteRolePermissionCommand : IRequest<bool>
    {
        public int Id { get; set; }

        public DeleteRolePermissionCommand(int id)
        {
            Id = id;
        }
    }
}

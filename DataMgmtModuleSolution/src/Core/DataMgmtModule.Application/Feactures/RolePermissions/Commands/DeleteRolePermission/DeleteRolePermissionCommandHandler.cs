using MediatR;
using System.Threading;
using System.Threading.Tasks;
using DataMgmtModule.Application.Interface.Persistence;

namespace DataMgmtModule.Application.Features.RolePermissions.Commands.DeleteRolePermission
{
    public class DeleteRolePermissionHandler : IRequestHandler<DeleteRolePermissionCommand, bool>
    {
        private readonly IRolePermissionRepository _repository;

        public DeleteRolePermissionHandler(IRolePermissionRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteRolePermissionCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.Id);
            if (entity == null)
                return false;

            await _repository.DeleteAsync(entity);
            return true;
        }
    }
}

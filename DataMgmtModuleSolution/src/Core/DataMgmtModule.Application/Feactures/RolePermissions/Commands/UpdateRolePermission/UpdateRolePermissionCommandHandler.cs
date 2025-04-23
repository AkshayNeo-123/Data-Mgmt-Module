using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using DataMgmtModule.Application.Interface.Persistence;
using DataMgmtModule.Application.Features.RolePermissions.DTOs;

namespace DataMgmtModule.Application.Features.RolePermissions.Commands.UpdateRolePermission
{
    public class UpdateRolePermissionHandler : IRequestHandler<UpdateRolePermissionCommand, RolePermissionDto>
    {
        private readonly IRolePermissionRepository _repository;
        private readonly IMapper _mapper;

        public UpdateRolePermissionHandler(IRolePermissionRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<RolePermissionDto> Handle(UpdateRolePermissionCommand request, CancellationToken cancellationToken)
        {
            var existing = await _repository.GetByIdAsync(request.Id);
            if (existing == null)
                return null;

            _mapper.Map(request.RolePermission, existing); 
            await _repository.UpdateAsync(existing);

            return _mapper.Map<RolePermissionDto>(existing);
        }
    }
}

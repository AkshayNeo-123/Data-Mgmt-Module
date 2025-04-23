using AutoMapper;
using MediatR;
using DataMgmtModule.Domain.Entities;
using DataMgmtModule.Application.Interface.Persistence;
using DataMgmtModule.Application.Features.RolePermissions.DTOs;
using System.Threading;
using System.Threading.Tasks;
using Domain = DataMgmtModule.Domain.Entities;

namespace DataMgmtModule.Application.Features.RolePermissions.Commands.CreateRolePermission
{
    public class CreateRolePermissionHandler : IRequestHandler<CreateRolePermissionCommand, RolePermissionDto>
    {
         readonly IRolePermissionRepository _repository;
         readonly IMapper _mapper;

        public CreateRolePermissionHandler(IRolePermissionRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<RolePermissionDto> Handle(CreateRolePermissionCommand request, CancellationToken cancellationToken)
        {
            var addpermission = _mapper.Map<RolePermission>(request.RolePermission);
            var result = await _repository.AddAsync(addpermission);
            return _mapper.Map<RolePermissionDto>(result);
        }
    }
}

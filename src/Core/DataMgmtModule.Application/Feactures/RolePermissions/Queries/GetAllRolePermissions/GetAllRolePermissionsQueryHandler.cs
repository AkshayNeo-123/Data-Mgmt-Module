//using AutoMapper;
//using MediatR;
//using DataMgmtModule.Application.Features.RolePermissions.DTOs;
//using DataMgmtModule.Application.Interface.Persistence;

//namespace DataMgmtModule.Application.Features.RolePermissions.Queries.GetAllRolePermissions
//{
//    public class GetAllRolePermissionsHandler : IRequestHandler<GetAllRolePermissionsQuery, List<RolePermissionDto>>
//    {
//        private readonly IRolePermissionRepository _roleRepository;
//        private readonly IMapper _mapper;

//        public GetAllRolePermissionsHandler(IRolePermissionRepository roleRepository, IMapper mapper)
//        {
//            _roleRepository = roleRepository;
//            _mapper = mapper;
//        }

//        public async Task<List<RolePermissionDto>> Handle(GetAllRolePermissionsQuery request, CancellationToken cancellationToken)
//        {
//            var list = await _roleRepository.GetAllAsync();
//            return _mapper.Map<List<RolePermissionDto>>(list);
//        }
//    }
//}


using MediatR;
using AutoMapper;
using DataMgmtModule.Application.Interface.Persistence;
using DataMgmtModule.Application.Features.RolePermissions.DTOs;


namespace DataMgmtModule.Application.Features.RolePermissions.Queries.GetAllRolePermissions
{
    public class GetAllRolePermissionsHandler : IRequestHandler<GetAllRolePermissionsQuery, List<RolePermissionDto>>
    {
        private readonly IRolePermissionRepository _repository;
        private readonly IMapper _mapper;

        public GetAllRolePermissionsHandler(IRolePermissionRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<RolePermissionDto>> Handle(GetAllRolePermissionsQuery request, CancellationToken cancellationToken)
        {
            var rolePermissions = await _repository.GetAllAsync();
            return _mapper.Map<List<RolePermissionDto>>(rolePermissions);
        }
    }
}


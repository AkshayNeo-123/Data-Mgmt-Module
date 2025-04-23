using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using DataMgmtModule.Application.Interface.Persistence;
using DataMgmtModule.Application.Features.RolePermissions.DTOs;

namespace DataMgmtModule.Application.Features.RolePermissions.Queries.GetById
{
    public class GetRolePermissionByIdHandler : IRequestHandler<GetRolePermissionByIdQuery, RolePermissionDto>
    {
        private readonly IRolePermissionRepository _repository;
        private readonly IMapper _mapper;

        public GetRolePermissionByIdHandler(IRolePermissionRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<RolePermissionDto> Handle(GetRolePermissionByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.Id);
            return _mapper.Map<RolePermissionDto>(entity);
        }
    }
}

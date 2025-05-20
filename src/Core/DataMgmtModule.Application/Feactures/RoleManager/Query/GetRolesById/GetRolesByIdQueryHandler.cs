using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Application.Dtos.RoleManagerDto;
using DataMgmtModule.Application.Interface.Persistence;
using DataMgmtModule.Domain.Entities;
using MediatR;

namespace DataMgmtModule.Application.Feactures.RoleManager.Query.GetRolesById
{
    public class GetRolesByIdQueryHandler : IRequestHandler<GetRolesbyIdQuery, GetRoleDto?>
    {
        private readonly IRoleRepository _roleRepository;
        public GetRolesByIdQueryHandler(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }
        public async Task<GetRoleDto?> Handle(GetRolesbyIdQuery request, CancellationToken cancellationToken)
        {
            var getData = await _roleRepository.GetRolesByIdAsync(request.Id);
            return getData;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Application.Dtos.RoleManagerDto;
using DataMgmtModule.Application.Interface.Persistence;
using DataMgmtModule.Domain.Entities;
using MediatR;

namespace DataMgmtModule.Application.Feactures.RoleManager.Query.GetAllRoles
{
    public class GetAllRolesQueryHandler : IRequestHandler<GetAllRolesQuery, IEnumerable<GetRoleDto>>
    {
        private IRoleRepository _roleRepository;
        public GetAllRolesQueryHandler(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<IEnumerable<GetRoleDto>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
        {
            return await _roleRepository.GetAllRoles();
        }
    }
}

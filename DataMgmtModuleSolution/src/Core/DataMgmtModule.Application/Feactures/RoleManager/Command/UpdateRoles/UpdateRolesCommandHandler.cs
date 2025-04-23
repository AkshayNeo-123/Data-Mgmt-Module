using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Application.Interface.Persistence;
using DataMgmtModule.Domain.Entities;
using MediatR;

namespace DataMgmtModule.Application.Feactures.RoleManager.Command.UpdateRoles
{
    public class UpdateRolesCommandHandler : IRequestHandler<UpdateRoleCommand, Roles>
    {
        private readonly IRoleRepository _roleRepository;
        public UpdateRolesCommandHandler(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;  
        }
        public async Task<Roles> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
        {
            var data =await _roleRepository.GetRolesByIdAsync(request.id);
           data.RoleName = request.UpdateRole.RoleName;
            data.Description= request.UpdateRole.Description;
            return await _roleRepository.UpdateRolesAsync(request.id, data);
        }
    }
}

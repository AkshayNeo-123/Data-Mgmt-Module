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
            //data.Description= request.UpdateRole.Description;
            //data.RoleManagement = request.UpdateRole.RoleManagement;
            //data.UserManagement = request.UpdateRole.UserManagement;
            //data.Materials = request.UpdateRole.Materials;
            //data.Project = request.UpdateRole.Project;
            //data.Recipe = request.UpdateRole.Recipe;
            //data.Testing = request.UpdateRole.Testing;
            //data.Dashboard = request.UpdateRole.Dashboard;
            //data.MasterTables = request.UpdateRole.MasterTables;
            return await _roleRepository.UpdateRolesAsync(request.id, data);
        }
    }
}

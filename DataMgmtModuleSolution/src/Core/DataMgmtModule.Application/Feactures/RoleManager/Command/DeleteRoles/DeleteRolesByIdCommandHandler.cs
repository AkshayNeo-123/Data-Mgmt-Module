using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Application.Interface.Persistence;
using DataMgmtModule.Domain.Entities;
using MediatR;

namespace DataMgmtModule.Application.Feactures.RoleManager.Command.DeleteRoles
{
    public class DeleteRolesByIdCommandHandler : IRequestHandler<DeleteRolesByIdCommand,Roles>
    {
        private readonly IRoleRepository _roleRepository;
        public DeleteRolesByIdCommandHandler(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository; 
        }
         async Task<Roles> IRequestHandler<DeleteRolesByIdCommand, Roles>.Handle(DeleteRolesByIdCommand request, CancellationToken cancellationToken)
        {
            var getData=await _roleRepository.GetRolesByIdAsync(request.Id);
            return await _roleRepository.DeleteAccountByIdAsync(getData.RoleId);
           
        }
    }
}

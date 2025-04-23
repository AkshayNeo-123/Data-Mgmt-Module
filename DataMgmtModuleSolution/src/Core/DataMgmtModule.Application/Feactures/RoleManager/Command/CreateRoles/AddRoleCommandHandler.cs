using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataMgmtModule.Application.Interface.Persistence;
using DataMgmtModule.Domain.Entities;
using MediatR;

namespace DataMgmtModule.Application.Feactures.RoleManager.Command.CreateRoles
{
    public class AddRoleCommandHandler : IRequestHandler<AddRoleCommand, Roles>
    {
        private readonly IRoleRepository _rolesRepository;
        private readonly IMapper _mapper;
        public AddRoleCommandHandler(IRoleRepository roleRepository, IMapper mapper)
        {
            _rolesRepository = roleRepository;
            _mapper = mapper;
        }
        public Task<Roles> Handle(AddRoleCommand request, CancellationToken cancellationToken)
        {
            var addData = _mapper.Map<Roles>(request.addRole);
            var data = _rolesRepository.AddRolesAsync(addData);
            return data;

        }
    }
}

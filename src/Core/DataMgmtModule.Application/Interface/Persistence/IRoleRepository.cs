using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Application.Dtos.RoleManagerDto;
using DataMgmtModule.Domain.Entities;

namespace DataMgmtModule.Application.Interface.Persistence
{
    public interface IRoleRepository
    {
        Task<Roles> AddRolesAsync(Roles roles);
        Task<IEnumerable<GetRoleDto>> GetAllRoles();
        Task<GetRoleDto?> GetRolesByIdAsync(int id);
        Task<Roles> DeleteAccountByIdAsync(int id);
        Task<GetRoleDto>UpdateRolesAsync(int id,GetRoleDto roles);
    }
}

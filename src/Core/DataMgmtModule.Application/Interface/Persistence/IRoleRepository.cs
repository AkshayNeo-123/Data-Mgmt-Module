using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Domain.Entities;

namespace DataMgmtModule.Application.Interface.Persistence
{
    public interface IRoleRepository
    {
        Task<Roles> AddRolesAsync(Roles roles);
        Task<IEnumerable<Roles>> GetAllRoles();
        Task<Roles> GetRolesByIdAsync(int id);
        Task<Roles> DeleteAccountByIdAsync(int id);
        Task<Roles>UpdateRolesAsync(int id,Roles roles);
    }
}

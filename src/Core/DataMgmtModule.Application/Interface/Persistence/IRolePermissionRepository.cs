using DataMgmtModule.Domain.Entities;

namespace DataMgmtModule.Application.Interface.Persistence
{
    public interface IRolePermissionRepository
    {
     
        Task<RolePermission> AddAsync(RolePermission rolePermission);
        Task<List<RolePermission>> GetAllAsync();

        Task<RolePermission> GetByIdAsync(int id);
        Task UpdateAsync(RolePermission rolePermission);

        Task DeleteAsync(RolePermission rolePermission);


    }
}

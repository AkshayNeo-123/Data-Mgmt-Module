using DataMgmtModule.Application.Interface.Persistence;

using DataMgmtModule.Domain.Entities;

using Microsoft.EntityFrameworkCore;

namespace DataMgmtModule.Persistence.Repository
{
    public class RolePermissionRepository : IRolePermissionRepository
    {
        private readonly PersistenceDbContext _context;

        public RolePermissionRepository(PersistenceDbContext context)
        {
            _context = context;
        }

        public async Task<List<RolePermission>> GetAllAsync()
        {
            return await _context.RolePermissions.ToListAsync();
        }


        public async Task<RolePermission> AddAsync(RolePermission rolePermission)
        {
            await _context.RolePermissions.AddAsync(rolePermission);
            await _context.SaveChangesAsync();
            return rolePermission;
        }

        public async Task<RolePermission> GetByIdAsync(int id)
        {
            return await _context.RolePermissions.FindAsync(id);
        }

        public async Task UpdateAsync(RolePermission rolePermission)
        {
            //foreach(var rolesP in rolePermission)
            //{

            //}
            _context.RolePermissions.Update(rolePermission);
            await _context.SaveChangesAsync();
        }


        public async Task DeleteAsync(RolePermission rolePermission)
        {
            _context.RolePermissions.Remove(rolePermission);
            await _context.SaveChangesAsync();
        }

    }
}

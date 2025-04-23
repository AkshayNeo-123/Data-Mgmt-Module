using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Application.Interface.Persistence;
using DataMgmtModule.Domain.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DataMgmtModule.Persistence.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly PersistenceDbContext _context;
        public RoleRepository(PersistenceDbContext context)
        {
            _context = context; 
        }

        public async Task<Roles> AddRolesAsync(Roles roles)
        {

             await _context.Roles.AddAsync(roles);
           await _context.SaveChangesAsync();
            return roles;
        }

        public async Task<Roles> DeleteAccountByIdAsync(int id)
        {
            var getdata = await _context.Roles.FindAsync(id);
            _context.Remove(getdata);
            await _context.SaveChangesAsync();
            return getdata;
        }

        public async Task<IEnumerable<Roles>> GetAllRoles()
        {
            return await _context.Roles.ToListAsync();
        }

        public async Task<Roles>GetRolesByIdAsync(int id)
        {
            var getData =await _context.Roles.FirstOrDefaultAsync(x => x.RoleId == id);
            return getData;

        }

        public async Task<Roles> UpdateRolesAsync(int id, Roles roles)
        {
            var getData = await _context.Roles.FindAsync(id);
            _context.Update(getData);
            await _context.SaveChangesAsync();
            return roles;
        }
    }
}

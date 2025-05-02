using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Application.Dtos;
using DataMgmtModule.Application.Interface.Persistence;
using DataMgmtModule.Application.Models;
using DataMgmtModule.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataMgmtModule.Persistence.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly PersistenceDbContext _context;
        public UserRepository(PersistenceDbContext context)
        {
            _context = context;
        }

        public User? ValidateUser(string email, string password)
        {
            return _context.Users
                .FromSqlRaw("EXEC sp_CheckUserLogin @Email = {0}, @PasswordHash = {1}", email, password)
                .AsEnumerable()
                .FirstOrDefault();
        }

        public async Task<List<User>> GetAllUsersAsync() => 
            await _context.Users
                .Include(z=>z.Role)
                .Where(u=>!u.isDelete)
                .ToListAsync();
        public async Task<User?> GetUserByIdAsync(int id) => await _context.Users.FindAsync(id);
        public async Task<User> AddUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }
        public async Task<bool> UpdateUserAsync(int id, UpdateUserDto user)
        {
            var existing = await _context.Users.FirstOrDefaultAsync(u=>u.UserId==id);
            if (existing == null) return false;

            _context.Entry(existing).CurrentValues.SetValues(user);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if(user == null) return false;

            user.isDelete = true;
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}

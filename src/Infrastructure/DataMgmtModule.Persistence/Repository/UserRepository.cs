using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Application.Dtos;
using DataMgmtModule.Application.Interface.Persistence;
using DataMgmtModule.Application.Models;
using DataMgmtModule.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using DataMgmtModule.Application.Exceptions;
using DataMgmtModule.Application.Dtos.User;

namespace DataMgmtModule.Persistence.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly PersistenceDbContext _context;
        private readonly IPasswordHasher<User> _passwordHasher;
        public UserRepository(PersistenceDbContext context, IPasswordHasher<User> passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
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
            user.CreatedDate = DateTime.Now;
            //user.Otp = null;
            //user.OtpExpiry = null;
            //user.OtpVerified = false;
            //var OgPw = user.PasswordHash;
            user.PasswordHash = _passwordHasher.HashPassword(user, user.PasswordHash);
            _context.Users.Add(user);
            
            await _context.SaveChangesAsync();
            return user;
        }
        public async Task<bool> UpdateUserAsync(int id, UpdateUserDto user)
        {

            var existing = await _context.Users.FirstOrDefaultAsync(u=>u.UserId==id);
            if (existing == null) return false;

            _context.Entry(existing).CurrentValues.SetValues(user);
            existing.ModifiedDate = DateTime.Now;
            //existing.PasswordHash = _passwordHasher.HashPassword(user, user.PasswordHash);
            if (!string.IsNullOrWhiteSpace(user.PasswordHash) &&
                    !user.PasswordHash.StartsWith("AQAAAA")) // crude check for already-hashed password
            {
                var passwordHasher = new PasswordHasher<User>();
                existing.PasswordHash = passwordHasher.HashPassword(existing, user.PasswordHash);
            }
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteUserAsync(int id, int? deletedBy)
        {
            var user = await _context.Users.FindAsync(id);
            if(user == null) return false;
            user.Status = "InActive";
            user.isDelete = true;
            user.DeletedDate = DateTime.Now;
            user.DeletedBy = deletedBy;
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email)
                ?? throw new NotFoundException($"User with email {email} not found");
        }

        public async Task SendOtpAsync(User user, string otp)
        {
            user.Otp = otp;
            user.OtpExpiry = DateTime.UtcNow.AddMinutes(10);
            user.OtpVerified = false;
            
            await _context.SaveChangesAsync();
        }

        public async Task<bool> VerifyOtpAsync(string email, string otp)
        {
            var user = await GetByEmailAsync(email);
            if (user == null || user.Otp != otp || user.OtpExpiry < DateTime.UtcNow || user.OtpVerified==true) return false;

            user.OtpVerified = true;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task ResetPasswordAsync(string email, string newPassword)
        {
            var user = await GetByEmailAsync(email);
            if (user == null || !user.OtpVerified) throw new Exception("OTP not verified or user not found.");

            var newHashedPassword = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, newPassword);
            if (newHashedPassword == PasswordVerificationResult.Success) throw new Exception("You cannot keep the same password as previous!");

            user.PasswordHash = _passwordHasher.HashPassword(user, newPassword);
            //user.PasswordHash = newHashedPassword;
            user.Otp = null;
            user.OtpExpiry = null;
            user.OtpVerified = false;

            await _context.SaveChangesAsync();
        }

        public async Task<bool> ChangePasswordAsync(int id,ChangePasswordDto changePasswordDto)
        {
            var getUser =await _context.Users.FindAsync(id);
            if (getUser == null) return false;
            var result = _passwordHasher.VerifyHashedPassword(getUser, getUser.PasswordHash, changePasswordDto.OldPassword);
            if (result!=PasswordVerificationResult.Success || getUser.PasswordHash == changePasswordDto.NewPassword)
            {
                throw new InvalidOperationException("The current password you entered is incorrect.");
            }
            //if (getUser.PasswordHash != changePasswordDto.OldPassword || getUser.PasswordHash == changePasswordDto.NewPassword)
            //{
            //    throw new InvalidOperationException("The current password you entered is incorrect.");
            //}
            //getUser.PasswordHash = changePasswordDto.NewPassword;
            getUser.PasswordHash = _passwordHasher.HashPassword(getUser, changePasswordDto.NewPassword);
            getUser.ModifiedBy = changePasswordDto.ModifiedBy;
            getUser.ModifiedDate = DateTime.Now;
            _context.Update(getUser);
            await _context.SaveChangesAsync();
            return true;


        }
    }
}

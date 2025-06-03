using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Application.Exceptions;
using DataMgmtModule.Application.Interface.Persistence;
using DataMgmtModule.Application.Models.Authentication;
using DataMgmtModule.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace DataMgmtModule.Persistence.Repository
{
    public class AuthRepository : IAuth
    {
        private readonly PersistenceDbContext _persistenceDbContext;
        public AuthRepository(PersistenceDbContext persistenceDbContext)
        {
            _persistenceDbContext = persistenceDbContext;
        }
        public async Task<LoginResponse> Login(LoginRequest loginRequest)
        {
            if (loginRequest.Email == null || loginRequest.Password == null)
            {
                throw new NotFoundException("Email and Password is required!!");
            }
            var user = await _persistenceDbContext.Users
        .FirstOrDefaultAsync(x => x.Email == loginRequest.Email);
            var email = await _persistenceDbContext.Users.Where(x => x.Email == loginRequest.Email).FirstOrDefaultAsync();
            if (email == null)
            {
                throw new NotFoundException("Invalid Username or Password");
            }
            var passwordHasher = new PasswordHasher<User>();
            var result = passwordHasher.VerifyHashedPassword(user, user.PasswordHash, loginRequest.Password);
            if (result != PasswordVerificationResult.Success)      
            {
                throw new NotFoundException("Invalid Username or Password");
            }

            if (email.Status.Equals("InActive") || email.isDelete == true)
            {
                throw new InActiveUserException("User doesn't exist");
            }
            var response = new LoginResponse
            {
                UserId = email.UserId,
                Email = email.Email,
                RoleId = email.RoleId.Value,
            };
            return response;

        }
    }
        
}

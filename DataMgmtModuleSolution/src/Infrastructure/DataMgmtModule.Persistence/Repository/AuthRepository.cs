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
            var email = await _persistenceDbContext.Users.Where(x => x.Email == loginRequest.Email).FirstOrDefaultAsync();
            if (email == null)
            {
                throw new NotFoundException("Email Id is Wrong");
            }
            if (email.PasswordHash != loginRequest.Password)
            {
                throw new NotFoundException("Password is Wrong");
            }

            if (email.Status.Equals("InActive"))
            {
                throw new InActiveUserException("User is InActive");
            }
            var response = new LoginResponse
            {
                UserId = email.UserId,
                Email = email.Email,

            };
            return response;

        }
    }
        
}

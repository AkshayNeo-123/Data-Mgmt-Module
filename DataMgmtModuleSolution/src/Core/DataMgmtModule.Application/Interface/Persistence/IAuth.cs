using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Application.Models.Authentication;

namespace DataMgmtModule.Application.Interface.Persistence
{
    public interface IAuth
    {
        Task<LoginResponse> Login(LoginRequest loginRequest);
    }
}

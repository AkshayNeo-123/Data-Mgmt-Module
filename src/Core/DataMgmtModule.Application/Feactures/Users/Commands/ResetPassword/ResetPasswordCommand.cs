using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DataMgmtModule.Application.Feactures.Users.Commands.ResetPassword
{
    public class ResetPasswordCommand : IRequest<bool>
    {
        public string Email { get; set; }
        public string NewPassword { get; set; }
    }
}

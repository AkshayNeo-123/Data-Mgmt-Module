using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DataMgmtModule.Application.Feactures.Users.Commands.SendOtp
{
    public class SendOtpCommand : IRequest<bool>
    {
        public string Email { get; set; }
        public SendOtpCommand(string email)
        {
            this.Email = email;
        }
    }
}

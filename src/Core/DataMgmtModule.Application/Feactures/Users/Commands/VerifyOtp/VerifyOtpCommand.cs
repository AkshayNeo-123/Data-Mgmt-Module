using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DataMgmtModule.Application.Feactures.Users.Commands.VerifyOtp
{
    public class VerifyOtpCommand : IRequest<bool>
    {
        public string Email { get; set; }
        public string Otp { get; set; }
    }
}

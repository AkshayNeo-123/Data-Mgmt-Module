using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Application.Interface.Persistence;
using MediatR;
//using NETCore.MailKit.Core;

namespace DataMgmtModule.Application.Feactures.Users.Commands.SendOtp
{
    public class SendOtpCommandHandler : IRequestHandler<SendOtpCommand, bool>
    {
        private readonly IUserRepository _userRepository;
        private readonly DataMgmtModule.Application.Interface.Persistence.IEmailServiceRepository _emailService;
        public SendOtpCommandHandler(IUserRepository userRepository, IEmailServiceRepository emailService)
        {
            _userRepository = userRepository;
            _emailService = emailService;
        }
        public async Task<bool> Handle(SendOtpCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _userRepository.GetByEmailAsync(request.Email);
                if (user == null) throw new Exception("Email not found");

                if (string.IsNullOrWhiteSpace(user.Email)) throw new Exception("User email is empty or null");

                var otp = new Random().Next(100000, 999999).ToString();
                await _userRepository.SendOtpAsync(user, otp);
                await _emailService.SendEmailAsync(user.Email, "OTP", $"Your OTP is {otp}");

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("SendOtpCommandHandler failed: " + ex.Message, ex);
            }


        }
    }
}

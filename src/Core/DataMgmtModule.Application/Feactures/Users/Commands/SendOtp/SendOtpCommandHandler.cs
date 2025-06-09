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
                //await _emailService.SendEmailAsync(user.Email, "Reset Your Password – OTP Verification", $"Your OTP is {otp}");
                //await _emailService.SendEmailAsync(
                //    user.Email, 
                //    "Reset Your Password – OTP Verification",
                //    $"Dear {user.FirstName},\r\n" +
                //    $"You have requested to reset your password. To proceed, please use the One-Time Password (OTP) provided below:\r\n" +
                //    $"OTP: {otp}\r\n" +
                //    $"This OTP is valid for 10 minutes and can be used only once. If you did not initiate this request, please ignore this email.\r\nFor security reasons, do not share this OTP with anyone. If you need any assistance, please contact our support team at dmmadmin@gmail.com.\r\nBest regards,\r\nDMM Support"
                //    );
                await _emailService.SendEmailAsync(
                    user.Email,
                    "Reset Your Password – OTP Verification",
                    $@"<html>
                        <body>
                            <p><strong>Dear {user.FirstName},</strong></p>
                            <p>You have requested to reset your password. To proceed, please use the One-Time Password (OTP) provided below:</p>
                            <p><div style='text-align: center; margin: 20px 0;'>
                                <span style='font-size: 18px; font-weight: bold; color: #2c3e50;'>{otp}</span>
                                </div></p>
                            <p>This OTP is valid for 10 minutes and can be used only once.</p>
                            <p>If you did not initiate this request, please ignore this email.</p>
                            <p>For security reasons, do not share this OTP with anyone.</p>
                            <p>If you need any assistance, please contact our support team at 
                            <a href='mailto:dmmadmin@gmail.com'>dmmadmin@gmail.com</a>.</p>
                            <p><strong>Best regards,</strong><br/>DMM Support</p>
                        </body>
                    </html>"
                    );

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }


        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataMgmtModule.Application.Interface.Persistence;
using DataMgmtModule.Application.Models;
using DataMgmtModule.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace DataMgmtModule.Application.Feactures.Users.Commands.AddUser
{
    public class AddUserCommandHandler : IRequestHandler<AddUserCommand, User>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly DataMgmtModule.Application.Interface.Persistence.IEmailServiceRepository _emailService;

        public AddUserCommandHandler(IUserRepository userRepository, IMapper mapper, IEmailServiceRepository emailService)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _emailService = emailService;
        }
        public async Task<User> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var mapped = _mapper.Map<User>(request.user);
            string plainPassword = mapped.PasswordHash;
            var created = await _userRepository.AddUserAsync(mapped);
            string subject = "Welcome to DMM!";
            string body= $@"<html>
            <body>
                <p><strong>Dear {created.FirstName},</strong></p>
                <p>Your account has been successfully created by the admin.</p>
                <p>Enter your email as the Username and your Password is: {plainPassword}</p>
                <p>You can now log in and begin using the system. For your security, please change your password immediately after login.</p>
                <p>If you have any questions, please contact us at 
                   <a href='mailto:dmmadmin@gmail.com'>dmmadmin@gmail.com</a>.</p>
                <p><strong>Best regards,</strong><br/>DMM Support Team</p>
            </body>
        </html>";

            await _emailService.SendEmailAsync(created.Email, subject, body, isHtml: true);
            return created;
        }
    }
}

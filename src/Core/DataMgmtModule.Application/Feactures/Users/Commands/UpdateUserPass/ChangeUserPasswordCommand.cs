using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Application.Dtos.User;
using MediatR;

namespace DataMgmtModule.Application.Feactures.Users.Commands.UpdateUserPass
{
    public record ChangeUserPasswordCommand(int id,ChangePasswordDto changePasswordDto):IRequest<bool>
    {
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Application.Dtos;
using MediatR;

namespace DataMgmtModule.Application.Feactures.Users.Commands.UpdateUser
{
    public record UpdateUserCommand(int id, UpdateUserDto user):IRequest<bool>;
    
}

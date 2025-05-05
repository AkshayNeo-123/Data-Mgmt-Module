using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Application.Dtos.ContactDTO;
using MediatR;

namespace DataMgmtModule.Application.Feactures.ContactFeatures.Command.UpdateContacts
{
    public record UpdateContactQuery(int id, AddContactDTO addContactDTO,int? userId):IRequest<bool>
    {
    }
}

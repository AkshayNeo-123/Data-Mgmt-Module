using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Application.Dtos.ContactDTO;
using DataMgmtModule.Domain.Entities;
using MediatR;

namespace DataMgmtModule.Application.Feactures.ContactFeatures.Query.GetById
{
    public record GetContactsByIdQuery(int id):IRequest<AddContactDTO>
    {
    }
}

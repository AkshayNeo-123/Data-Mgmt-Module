using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DataMgmtModule.Application.Feactures.ContactFeatures.Command.DeleteContactData
{
    public record DeleteContactQuery(int id):IRequest<bool>
    {
    }
}

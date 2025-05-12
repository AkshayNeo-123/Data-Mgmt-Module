using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DataMgmtModule.Application.Feactures.MainPolymerFeatures.Command.DeleteMainPolymer
{
    public record DeleteMainPolymerCommand(int Id,int deletedBy) : IRequest<bool>;
}

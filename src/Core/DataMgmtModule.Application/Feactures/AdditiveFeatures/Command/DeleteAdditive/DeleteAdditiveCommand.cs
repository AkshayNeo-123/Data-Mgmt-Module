using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DataMgmtModule.Application.Feactures.AdditiveFeatures.Command.DeleteAdditive
{
    public record DeleteAdditiveCommand(int Id) : IRequest<bool>;
}

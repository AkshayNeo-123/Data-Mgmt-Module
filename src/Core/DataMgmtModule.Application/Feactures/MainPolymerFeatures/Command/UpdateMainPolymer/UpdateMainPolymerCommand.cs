using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Application.Dtos.MainPolymerDtos;
using MediatR;

namespace DataMgmtModule.Application.Feactures.MainPolymerFeatures.Command.UpdateMainPolymer
{
    public record UpdateMainPolymerCommand(int Id, UpdateMainPolymerDto Polymer, int? userId) : IRequest<bool>;
}

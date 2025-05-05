using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Application.Dtos.AdditiveDtos;
using MediatR;

namespace DataMgmtModule.Application.Feactures.AdditiveFeatures.Command.UpdateAdditive
{
    public record UpdateAdditiveCommand(int Id, UpdateAdditiveDto Additive, int? userId) : IRequest<bool>;
}

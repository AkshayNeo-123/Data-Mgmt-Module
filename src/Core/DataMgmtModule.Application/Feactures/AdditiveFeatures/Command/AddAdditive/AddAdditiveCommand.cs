using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Application.Dtos.AdditiveDtos;
using DataMgmtModule.Domain.Entities;
using MediatR;

namespace DataMgmtModule.Application.Feactures.AdditiveFeatures.Command.AddAdditive
{
    public record AddAdditiveCommand(CreateAdditiveDto Additive,int? userId) : IRequest<DisplayAdditive>;
}

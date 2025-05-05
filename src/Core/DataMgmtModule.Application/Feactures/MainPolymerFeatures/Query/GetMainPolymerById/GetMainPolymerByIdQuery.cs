using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Application.Dtos.MainPolymerDtos;
using DataMgmtModule.Domain.Entities;
using MediatR;

namespace DataMgmtModule.Application.Feactures.MainPolymerFeatures.Query.GetMainPolymerById
{
    public record GetMainPolymerByIdQuery(int Id) : IRequest<DisplayMainPolymer>;
}

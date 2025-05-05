using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Application.Dtos.AdditiveDtos;
using DataMgmtModule.Domain.Entities;
using MediatR;

namespace DataMgmtModule.Application.Feactures.AdditiveFeatures.Query.GetAllAdditives
{
    public record GetAllAdditivesQuery() : IRequest<IEnumerable<DisplayAdditive>>;
}

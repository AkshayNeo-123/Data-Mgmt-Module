using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Domain.Entities;
using MediatR;

namespace DataMgmtModule.Application.Feactures.StatesMaster.StateFeatures.AddStateData
{
    public record AddStateQuery(States states):IRequest<States>
    {
    }
}

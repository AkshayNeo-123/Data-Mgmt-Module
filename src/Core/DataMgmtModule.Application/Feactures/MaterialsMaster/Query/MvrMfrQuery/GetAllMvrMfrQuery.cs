using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Domain.Entities;
using MediatR;

namespace DataMgmtModule.Application.Feactures.MaterialsMaster.Query.MvrMfrQuery
{

    public class GetAllMvrMfrQuery : IRequest<IEnumerable<MvrMfr>>
    {
    }
}

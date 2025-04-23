using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DataMgmtModule.Application.Feactures.CompoundingDatas.Command.DeleteCompoundingData
{
    public record DeleteCompoundingDataCommand(int id):IRequest<int>
    {
    }
}

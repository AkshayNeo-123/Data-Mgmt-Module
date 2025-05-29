using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DataMgmtModule.Application.Feactures.TestFeactures.Commands
{
    public record DeleteTestCommand(int testId):IRequest<int>;
    
}

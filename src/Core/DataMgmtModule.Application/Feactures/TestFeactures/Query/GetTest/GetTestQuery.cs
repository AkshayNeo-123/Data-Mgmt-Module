using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Application.Dtos.TestDtos;
using MediatR;

namespace DataMgmtModule.Application.Feactures.TestFeactures.Query.GetTest
{
    public record GetTestQuery:IRequest<IEnumerable<TestDto>>;
    
}

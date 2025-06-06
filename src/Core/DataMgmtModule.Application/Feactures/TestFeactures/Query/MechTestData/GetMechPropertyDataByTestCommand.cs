using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Application.Dtos.TestDtos;
using MediatR;

namespace DataMgmtModule.Application.Feactures.TestFeactures.Query.MechTestData
{
    public record GetMechPropertyDataByTestCommand(int testId):IRequest<MechanicalPropertyDto>
    {
    }
}

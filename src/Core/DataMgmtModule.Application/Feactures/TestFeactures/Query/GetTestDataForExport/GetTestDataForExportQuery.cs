using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Application.Dtos.TestDtos;
using DataMgmtModule.Domain.Entities;
using MediatR;

namespace DataMgmtModule.Application.Feactures.TestFeactures.Query.GetTestDataForExport
{
    public record GetTestDataForExportQuery:IRequest<IEnumerable<ExportTestDataDto>>;
    
}

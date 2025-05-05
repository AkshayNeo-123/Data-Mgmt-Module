using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Domain.Entities;
using MediatR;

namespace DataMgmtModule.Application.Feactures.ProjectTypeFeactures.Query.GetAllProjectTypes
{
    public record class GetAllProjectTypesQuery:IRequest<IEnumerable<ProjectTypes>>;
   
}

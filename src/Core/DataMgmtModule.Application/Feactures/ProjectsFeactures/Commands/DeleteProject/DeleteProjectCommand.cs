using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DataMgmtModule.Application.Feactures.ProjectsFeactures.Commands.DeleteProject
{
    public record DeleteProjectCommand(int id, int? deletedBy) : IRequest<int>;
    
}

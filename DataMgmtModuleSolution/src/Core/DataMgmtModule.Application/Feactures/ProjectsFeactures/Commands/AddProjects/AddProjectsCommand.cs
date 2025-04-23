using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Application.Dtos.ProjectsDtos;
using MediatR;

namespace DataMgmtModule.Application.Feactures.ProjectsFeactures.Commands.AddProjects
{
    public record AddProjectsCommand(AddProjectDto project) : IRequest<int>;
    

}

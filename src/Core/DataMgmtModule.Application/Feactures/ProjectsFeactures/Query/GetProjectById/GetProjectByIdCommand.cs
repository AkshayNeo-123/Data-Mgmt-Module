using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Application.Dtos.ProjectsDtos;
using MediatR;

namespace DataMgmtModule.Application.Feactures.ProjectsFeactures.Query.GetProjectById
{
    public record GetProjectByIdCommand(int id):IRequest<GetAllProjectsDto>;
    

}

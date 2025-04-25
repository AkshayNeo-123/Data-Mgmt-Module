using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Application.Interface.Persistence;
using MediatR;

namespace DataMgmtModule.Application.Feactures.ProjectsFeactures.Commands.DeleteProject
{
    public class DeleteProjectCommandHandler:IRequestHandler<DeleteProjectCommand, int>
    {
         readonly IProjects _projectsRepository;
        public DeleteProjectCommandHandler(IProjects projectsRepository)
        {
            _projectsRepository = projectsRepository;
        }
        public async Task<int> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            return await _projectsRepository.DeleteProject(request.id);
        }
    }
    
}

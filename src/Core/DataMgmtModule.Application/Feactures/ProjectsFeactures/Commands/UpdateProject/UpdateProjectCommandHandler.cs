using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataMgmtModule.Application.Interface.Persistence;
using DataMgmtModule.Domain.Entities;
using MediatR;

namespace DataMgmtModule.Application.Feactures.ProjectsFeactures.Commands.UpdateProject
{
    public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand, int>
    {
         readonly IProjects _projectsRepository;
        readonly IMapper _mapper;
        public UpdateProjectCommandHandler(IProjects projectsRepository, IMapper mapper)
        {
            _projectsRepository = projectsRepository;
            _mapper = mapper;
        }
        public async Task<int> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            var project =  _mapper.Map<Projects>(request.updateProject);
            return await _projectsRepository.UpdateProject(request.id,project,request.userId);
        }
    }
}

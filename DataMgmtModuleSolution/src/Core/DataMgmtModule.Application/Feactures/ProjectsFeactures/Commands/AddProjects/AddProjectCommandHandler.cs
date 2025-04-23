using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataMgmtModule.Application.Interface.Persistence;
using DataMgmtModule.Domain.Entities;
using MediatR;

namespace DataMgmtModule.Application.Feactures.ProjectsFeactures.Commands.AddProjects
{
    public class AddProjectCommandHandler : IRequestHandler<AddProjectsCommand, int>
    {
        readonly IProjects _projectsRepository;
        readonly IMapper _mapper;
        public AddProjectCommandHandler(IProjects projectsRepository,IMapper mapper)
        {
            _mapper = mapper;
            _projectsRepository = projectsRepository;
        }

        public async Task<int> Handle(AddProjectsCommand request, CancellationToken cancellationToken)
        {
            
            var projects =  _mapper.Map<Projects>(request.project);
            return await _projectsRepository.AddProject(projects);
            

        }
    }

}

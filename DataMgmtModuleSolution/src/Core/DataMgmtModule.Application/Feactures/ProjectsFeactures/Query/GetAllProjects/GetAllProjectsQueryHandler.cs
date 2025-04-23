using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataMgmtModule.Application.Dtos.ProjectsDtos;
using DataMgmtModule.Application.Interface.Persistence;
using MediatR;

namespace DataMgmtModule.Application.Feactures.ProjectsFeactures.Query.GetAllProjects
{
    public class GetAllProjectsQueryHandler : IRequestHandler<GetAllProjectsQuery, IEnumerable<GetAllProjectsDto>>
    {
         readonly IProjects _projectsRepository;
        readonly IMapper _mapper;

        public GetAllProjectsQueryHandler(IProjects projectsRepository, IMapper mapper)
        {
            _projectsRepository = projectsRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<GetAllProjectsDto>> Handle(GetAllProjectsQuery request, CancellationToken cancellationToken)
        {
            var projects= await _projectsRepository.GetAllProjects();
            var projectsDto = _mapper.Map<IEnumerable<GetAllProjectsDto>>(projects);
            return projectsDto;
        }
    }
}

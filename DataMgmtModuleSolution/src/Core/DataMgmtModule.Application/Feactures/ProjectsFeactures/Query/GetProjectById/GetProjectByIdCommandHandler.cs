using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataMgmtModule.Application.Dtos.ProjectsDtos;
using DataMgmtModule.Application.Interface.Persistence;
using MediatR;

namespace DataMgmtModule.Application.Feactures.ProjectsFeactures.Query.GetProjectById
{
    public class GetProjectByIdCommandHandler:IRequestHandler<GetProjectByIdCommand, GetAllProjectsDto>
    {
        readonly IProjects _projectsRepository;
        readonly IMapper _mapper;
        public GetProjectByIdCommandHandler(IProjects projectsRepository, IMapper mapper)
        {
            _projectsRepository = projectsRepository;
            _mapper = mapper;
        }
        public async Task<GetAllProjectsDto> Handle(GetProjectByIdCommand request, CancellationToken cancellationToken)
        {
            var project = await _projectsRepository.GetProjectById(request.id);
            var result = _mapper.Map<GetAllProjectsDto>(project);
            return result;
        }
    }
    
}

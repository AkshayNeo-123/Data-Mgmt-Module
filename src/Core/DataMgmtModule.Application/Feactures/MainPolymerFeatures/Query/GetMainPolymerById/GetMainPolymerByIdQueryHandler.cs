using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataMgmtModule.Application.Dtos.MainPolymerDtos;
using DataMgmtModule.Application.Interface.Persistence;
using DataMgmtModule.Domain.Entities;
using MediatR;

namespace DataMgmtModule.Application.Feactures.MainPolymerFeatures.Query.GetMainPolymerById
{
    public class GetMainPolymerByIdQueryHandler : IRequestHandler<GetMainPolymerByIdQuery, DisplayMainPolymer>
    {
        private readonly IMainPolymerRepository _repo;
        readonly IMapper _mapper;


        public GetMainPolymerByIdQueryHandler(IMainPolymerRepository repo,IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<DisplayMainPolymer> Handle(GetMainPolymerByIdQuery request, CancellationToken cancellationToken)
        {
            var polymer= await _repo.GetByIdAsync(request.Id);
            return _mapper.Map<DisplayMainPolymer>(polymer);
        }
    }
}

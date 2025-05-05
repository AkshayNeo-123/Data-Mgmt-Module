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

namespace DataMgmtModule.Application.Feactures.MainPolymerFeatures.Query.GetAllMainPolymers
{
    public class GetAllMainPolymersQueryHandler : IRequestHandler<GetAllMainPolymersQuery, IEnumerable<DisplayMainPolymer>>
    {
        private readonly IMainPolymerRepository _repo;
        readonly IMapper _mapper;


        public GetAllMainPolymersQueryHandler(IMainPolymerRepository repo,IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DisplayMainPolymer>> Handle(GetAllMainPolymersQuery request, CancellationToken cancellationToken)
        {
            var polymer= await _repo.GetAllAsync();
            var result= _mapper.Map < IEnumerable<DisplayMainPolymer>>(polymer);
            return result;
        }
    }
}

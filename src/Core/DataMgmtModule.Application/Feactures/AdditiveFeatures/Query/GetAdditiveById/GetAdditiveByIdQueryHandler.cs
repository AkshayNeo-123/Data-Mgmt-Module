using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataMgmtModule.Application.Dtos.AdditiveDtos;
using DataMgmtModule.Application.Interface.Persistence;
using DataMgmtModule.Domain.Entities;
using MediatR;

namespace DataMgmtModule.Application.Feactures.AdditiveFeatures.Query.GetAdditiveById
{
    public class GetAdditiveByIdQueryHandler : IRequestHandler<GetAdditiveByIdQuery, DisplayAdditive>
    {
        private readonly IAdditiveRepository _repo;
        readonly IMapper _mapper;   

        public GetAdditiveByIdQueryHandler(IAdditiveRepository repo,IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<DisplayAdditive> Handle(GetAdditiveByIdQuery request, CancellationToken cancellationToken)
        {
           var additive= await _repo.GetByIdAsync(request.Id);
            var result=_mapper.Map<DisplayAdditive>(additive);
            return result;
        }
    }
}

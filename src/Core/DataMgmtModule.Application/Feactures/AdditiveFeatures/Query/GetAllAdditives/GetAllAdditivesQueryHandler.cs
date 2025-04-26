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

namespace DataMgmtModule.Application.Feactures.AdditiveFeatures.Query.GetAllAdditives
{
    public class GetAllAdditivesQueryHandler : IRequestHandler<GetAllAdditivesQuery, IEnumerable<DisplayAdditive>>
    {
        private readonly IAdditiveRepository _repo;
        readonly IMapper _mapper;


        public GetAllAdditivesQueryHandler(IAdditiveRepository repo,IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DisplayAdditive>> Handle(GetAllAdditivesQuery request, CancellationToken cancellationToken)
        {
            var additive= await _repo.GetAllAsync();
            var result=_mapper.Map<IEnumerable<DisplayAdditive>>(additive);
            return result;
        }
    }
}

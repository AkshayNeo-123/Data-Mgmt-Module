using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataMgmtModule.Application.Dtos.AdditiveDtos;
using DataMgmtModule.Application.Dtos.MainPolymerDtos;
using DataMgmtModule.Application.Interface.Persistence;
using DataMgmtModule.Domain.Entities;
using MediatR;

namespace DataMgmtModule.Application.Feactures.AdditiveFeatures.Command.AddAdditive
{
    public class AddAdditiveCommandHandler : IRequestHandler<AddAdditiveCommand, DisplayAdditive>
    {
        private readonly IAdditiveRepository _repo;
        readonly IMapper _mapper;

        public AddAdditiveCommandHandler(IAdditiveRepository repo,IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<DisplayAdditive> Handle(AddAdditiveCommand request, CancellationToken cancellationToken)
        {
            var result= await _repo.AddAsync(request.Additive,request.userId);
            return _mapper.Map<DisplayAdditive>(result);
        }
    }
}

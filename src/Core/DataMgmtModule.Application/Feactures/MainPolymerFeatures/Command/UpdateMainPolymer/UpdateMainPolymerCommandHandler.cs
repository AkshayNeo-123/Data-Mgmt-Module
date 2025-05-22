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

namespace DataMgmtModule.Application.Feactures.MainPolymerFeatures.Command.UpdateMainPolymer
{
    public class UpdateMainPolymerCommandHandler : IRequestHandler<UpdateMainPolymerCommand, bool>
    {
        private readonly IMainPolymerRepository _repo;
        private readonly IMapper _mapper;
        public UpdateMainPolymerCommandHandler(IMainPolymerRepository repo,IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateMainPolymerCommand request, CancellationToken cancellationToken)
        {
            var getData = await _repo.GetByIdAsync(request.Id);
            var mapData = _mapper.Map<MainPolymer>(request.Polymer);
            var result = await _repo.UpdateAsync(request.Id,mapData,request.userId);
            return true;
        }
    }
}
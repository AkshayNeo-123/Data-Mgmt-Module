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

namespace DataMgmtModule.Application.Feactures.MainPolymerFeatures.Command.AddMainPolymer
{
    public class AddMainPolymerCommandHandler : IRequestHandler<AddMainPolymerCommand, DisplayMainPolymer>
    {
        private readonly IMainPolymerRepository _repo;
        readonly IMapper _mapper;


        public AddMainPolymerCommandHandler(IMainPolymerRepository repo,IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<DisplayMainPolymer> Handle(AddMainPolymerCommand request, CancellationToken cancellationToken)
        {
            var result= await _repo.AddAsync(request.Polymer,request.userId);
            return _mapper.Map<DisplayMainPolymer>(result);
        }
    }
}

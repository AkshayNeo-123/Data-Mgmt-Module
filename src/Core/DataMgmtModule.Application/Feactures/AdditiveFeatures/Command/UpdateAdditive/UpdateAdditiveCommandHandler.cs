using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataMgmtModule.Application.Interface.Persistence;
using MediatR;

namespace DataMgmtModule.Application.Feactures.AdditiveFeatures.Command.UpdateAdditive
{
    public class UpdateAdditiveCommandHandler : IRequestHandler<UpdateAdditiveCommand, bool>
    {
        private readonly IAdditiveRepository _repo;
        private readonly IMapper _mapper;

        public UpdateAdditiveCommandHandler(IAdditiveRepository repo,IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateAdditiveCommand request, CancellationToken cancellationToken)
        {
            var getData = await _repo.GetByIdAsync(request.Id);
            if (getData == null)
            {
                throw new Exception("Updated data not found");

            }
            var mapData = _mapper.Map(request.additive, getData);
            var updateData = await _repo.UpdateAsync(request.Id, mapData, request.userId);

            return true;
        }
    }
}

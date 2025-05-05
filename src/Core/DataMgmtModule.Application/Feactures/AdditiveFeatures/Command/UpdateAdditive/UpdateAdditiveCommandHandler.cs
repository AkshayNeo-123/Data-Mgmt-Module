using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Application.Interface.Persistence;
using MediatR;

namespace DataMgmtModule.Application.Feactures.AdditiveFeatures.Command.UpdateAdditive
{
    public class UpdateAdditiveCommandHandler : IRequestHandler<UpdateAdditiveCommand, bool>
    {
        private readonly IAdditiveRepository _repo;

        public UpdateAdditiveCommandHandler(IAdditiveRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(UpdateAdditiveCommand request, CancellationToken cancellationToken)
        {
            return await _repo.UpdateAsync(request.Id, request.Additive,request.userId);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Application.Interface.Persistence;
using MediatR;

namespace DataMgmtModule.Application.Feactures.MainPolymerFeatures.Command.UpdateMainPolymer
{
    public class UpdateMainPolymerCommandHandler : IRequestHandler<UpdateMainPolymerCommand, bool>
    {
        private readonly IMainPolymerRepository _repo;

        public UpdateMainPolymerCommandHandler(IMainPolymerRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(UpdateMainPolymerCommand request, CancellationToken cancellationToken)
        {
            return await _repo.UpdateAsync(request.Id, request.Polymer,request.userId);
        }
    }
}

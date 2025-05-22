using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Application.Interface.Persistence;
using MediatR;

namespace DataMgmtModule.Application.Feactures.MainPolymerFeatures.Command.DeleteMainPolymer
{
    public class DeleteMainPolymerCommandHandler : IRequestHandler<DeleteMainPolymerCommand, bool>
    {
        private readonly IMainPolymerRepository _repo;

        public DeleteMainPolymerCommandHandler(IMainPolymerRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(DeleteMainPolymerCommand request, CancellationToken cancellationToken)
        {
            return await _repo.DeleteAsync(request.Id,request.deletedBy);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Application.Interface.Persistence;
using MediatR;

namespace DataMgmtModule.Application.Feactures.AdditiveFeatures.Command.DeleteAdditive
{
    public class DeleteAdditiveCommandHandler : IRequestHandler<DeleteAdditiveCommand, bool>
    {
        private readonly IAdditiveRepository _repo;
        public DeleteAdditiveCommandHandler(IAdditiveRepository repo)
        {
            _repo = repo;
        }
        public async Task<bool> Handle(DeleteAdditiveCommand request,  CancellationToken cancellationToken)
        {
            return await _repo.DeleteAsync(request.Id);
        }
    }
}

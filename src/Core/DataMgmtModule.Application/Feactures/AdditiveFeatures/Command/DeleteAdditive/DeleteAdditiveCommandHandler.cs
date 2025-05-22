using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Application.Exceptions;
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
            var getData = await _repo.GetByIdAsync(request.Id);
            if (getData == null)
            {
                throw new NotFoundException("Data not found");
            }
            var deleteData = await _repo.DeleteAsync(getData.Id, request.deletedBy);
            return true;
            //return await _repo.DeleteAsync(request.Id,request.deletedBy);
        }
    }
}

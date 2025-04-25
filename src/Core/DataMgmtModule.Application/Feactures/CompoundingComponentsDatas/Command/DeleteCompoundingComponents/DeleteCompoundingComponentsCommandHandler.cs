using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Application.Interface.Persistence;
using DataMgmtModule.Domain.Entities;
using MediatR;

namespace DataMgmtModule.Application.Feactures.CompoundingComponentsDatas.Command.DeleteCompoundingComponents
{
    public class DeleteCompoundingComponentsCommandHandler : IRequestHandler<DeleteCompoundingComponentCommand, bool>
    {
        private readonly ICompoundingComponentsRepository _compoundingComponentsRepository;

        public DeleteCompoundingComponentsCommandHandler(ICompoundingComponentsRepository compoundingComponentsRepository)
        {
            _compoundingComponentsRepository = compoundingComponentsRepository;  
        }

        public async Task<bool> Handle(DeleteCompoundingComponentCommand request, CancellationToken cancellationToken)
        {
            var data = await _compoundingComponentsRepository.DeleteCompoundingComponents(request.Id,request.userId);
                return data;
        }


        
    }
}

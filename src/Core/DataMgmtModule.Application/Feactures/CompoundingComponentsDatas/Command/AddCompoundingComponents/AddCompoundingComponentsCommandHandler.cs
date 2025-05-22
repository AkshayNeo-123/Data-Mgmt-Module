using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataMgmtModule.Application.Feactures.CompoundingComponentsDates.Command.AddCompoundingComponents;
using DataMgmtModule.Application.Interface.Persistence;
using DataMgmtModule.Domain.Entities;
using MediatR;

namespace DataMgmtModule.Application.Feactures.CompoundingComponent.Command.AddCompoundingComponents
{
    public class AddCompoundingComponentsCommandHandler : IRequestHandler<AddCompoundingComponentsCommand, int>
    {
        ICompoundingComponentsRepository _repository;
        IMapper _mapper;
        public AddCompoundingComponentsCommandHandler(ICompoundingComponentsRepository compoundingComponentsRepository,IMapper mapper)
        {
            _repository= compoundingComponentsRepository;
            _mapper= mapper;
        }
        public async Task<int> Handle(AddCompoundingComponentsCommand request, CancellationToken cancellationToken)
        {
            int result = 0;
            foreach(var item in request.compoundingDataAndComponents.Components)
            {
               var data= _mapper.Map<Domain.Entities.CompoundingComponent>(item);
                data.RecipeId = request.compoundingDataAndComponents.CompoundingDataDTO.ReceipeId;

                result = await _repository.AddCompoundingComponents(request.Id, data,request.userId);
            }
            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataMgmtModule.Application.Interface.Persistence;
using DataMgmtModule.Domain.Entities;
using CompoundingDataComponent = DataMgmtModule.Domain.Entities.CompoundingComponent;
using MediatR;

namespace DataMgmtModule.Application.Feactures.CompoundingComponentsDatas.Command.UpdateCompoundingComponentsData
{
    public class UpdateCompoundingComponentsCommandHandler : IRequestHandler<UpdateCompoundingComponentsCommad, int>
    {
        private readonly ICompoundingComponentsRepository _compoundingComponentsRepository;
        private readonly IMapper _mapper;

        public UpdateCompoundingComponentsCommandHandler(ICompoundingComponentsRepository compoundingComponentsRepository,IMapper mapper)
        {
            _compoundingComponentsRepository = compoundingComponentsRepository;
            _mapper= mapper;    
        }
        public async Task<int> Handle(UpdateCompoundingComponentsCommad request, CancellationToken cancellationToken)
        {
            //int result = 0;
            //foreach (var item in request.compoundingDataAndComponents.Components)
            //{
            //    var data = _mapper.Map<CompoundingComponents>(item);
            //    result = await _compoundingComponentsRepository.UpdateCompoundingComponents(request.id, data);
            //}
            //return result;

            var mapComponent = _mapper.Map<CompoundingDataComponent[]>(request.compoundingDataAndComponents.Components);
            var updateData =await _compoundingComponentsRepository.UpdateCompoundingComponents(request.id, mapComponent);
            return updateData;
        }
    }
}

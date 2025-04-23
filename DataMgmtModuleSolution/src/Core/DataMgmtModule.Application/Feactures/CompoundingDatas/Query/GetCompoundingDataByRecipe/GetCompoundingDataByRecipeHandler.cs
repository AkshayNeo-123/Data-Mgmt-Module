using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Application.Interface.Persistence;
using DataMgmtModule.Domain.Entities;
using MediatR;

namespace DataMgmtModule.Application.Feactures.CompoundingDatas.Query.GetCompoundingDataByRecipe
{
    public class GetCompoundingDataByRecipeHandler : IRequestHandler<GetCompoundingDataByRecipe, IEnumerable<CompoundingDatum>>
    {
        private ICompoundingData _compoundingRepository;

        public GetCompoundingDataByRecipeHandler(ICompoundingData compoundingRepository)
        {
            _compoundingRepository = compoundingRepository;
        }

       
        async Task<IEnumerable<CompoundingDatum>> IRequestHandler<GetCompoundingDataByRecipe, IEnumerable<CompoundingDatum>>.Handle(GetCompoundingDataByRecipe request, CancellationToken cancellationToken)
        {
            var getData =await _compoundingRepository.GetCompoundingDataByRecipeAsync(request.Id);
            return getData;
        }
    }
}

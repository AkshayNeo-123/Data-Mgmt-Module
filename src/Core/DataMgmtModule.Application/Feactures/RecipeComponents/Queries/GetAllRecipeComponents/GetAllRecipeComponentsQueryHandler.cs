using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Application.Interface.Persistence;
using DataMgmtModule.Application.Models;
using DataMgmtModule.Domain.Entities;
using MediatR;

namespace DataMgmtModule.Application.Feactures.RecipeComponents.Queries.GetAllRecipeComponents
{
    public class GetAllRecipeComponentsQueryHandler : IRequestHandler<GetAllRecipeComponentsQuery, IEnumerable<RecipeComponent>>
    {
        private readonly IRecipeComponent _repository;

        public GetAllRecipeComponentsQueryHandler(IRecipeComponent repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<RecipeComponent>> Handle(GetAllRecipeComponentsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync();
        }
    }
}

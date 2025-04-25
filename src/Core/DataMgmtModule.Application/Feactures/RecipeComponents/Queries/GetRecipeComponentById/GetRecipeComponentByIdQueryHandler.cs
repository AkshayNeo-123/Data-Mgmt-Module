using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Application.Interface.Persistence;
using DataMgmtModule.Application.Models;
using DataMgmtModule.Domain.Entities;
using MediatR;

namespace DataMgmtModule.Application.Feactures.RecipeComponents.Queries.GetRecipeComponentById
{
    public class GetRecipeComponentByIdQueryHandler : IRequestHandler<GetRecipeComponentByIdQuery, RecipeComponent>
    {
        private readonly IRecipeComponent _repository;

        public GetRecipeComponentByIdQueryHandler(IRecipeComponent repository)
        {
            _repository = repository;
        }

        public async Task<RecipeComponent> Handle(GetRecipeComponentByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetByIdAsync(request.Id);
        }
    }
}

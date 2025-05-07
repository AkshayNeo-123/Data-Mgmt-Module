using MediatR;
using DataMgmtModule.Application.Interfaces.Persistence;
using DataMgmtModule.Application.Dtos.RecipeComponentTypeDto;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace DataMgmtModule.Application.Features.RecipeComponentTypes.Queries
{
    //public class GetAllRecipeComponentTypesQuery : IRequest<List<RecipeComponentTypeDto>>
    //{
    //}

    public class GetAllRecipeComponentTypesHandler : IRequestHandler<GetAllRecipeComponentTypesQuery, List<RecipeComponentTypeDto>>
    {
        private readonly IRecipeComponentTypeRepository _repository;

        public GetAllRecipeComponentTypesHandler(IRecipeComponentTypeRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<RecipeComponentTypeDto>> Handle(GetAllRecipeComponentTypesQuery request, CancellationToken cancellationToken)
        {
            var componentTypes = await _repository.GetAllAsync();


            return componentTypes.Select(ct => new RecipeComponentTypeDto
            {
                Id = ct.id,
                Type = ct.Type
            }).ToList();
        }
    }
}

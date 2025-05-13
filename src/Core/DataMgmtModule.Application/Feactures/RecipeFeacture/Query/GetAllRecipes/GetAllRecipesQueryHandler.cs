using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataMgmtModule.Application.Dtos.Materials;
using DataMgmtModule.Application.Dtos.RecipeDtos;
using DataMgmtModule.Application.Feactures.Materials.Query.GetAllMaterials;
using DataMgmtModule.Application.Interface.Persistence;
using MediatR;

namespace DataMgmtModule.Application.Feactures.RecipeFeacture.Query.GetAllRecipes
{
    public class GetAllRecipesQueryHandler : IRequestHandler<GetAllRecipesQuery, IEnumerable<GetAllRecipeDtos>>
    {
        private readonly IRecipe _recipeRepository;
        private readonly IMapper _mapper;

        public GetAllRecipesQueryHandler(IRecipe recipeRepository, IMapper mapper)
        {
            _recipeRepository = recipeRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetAllRecipeDtos>> Handle(GetAllRecipesQuery request, CancellationToken cancellationToken)
        {
            var recipes = await _recipeRepository.GetAllRecipes();
            return recipes;
          //  return _mapper.Map<IEnumerable<GetAllRecipeDtos>>(recipes);
        }
    }

}

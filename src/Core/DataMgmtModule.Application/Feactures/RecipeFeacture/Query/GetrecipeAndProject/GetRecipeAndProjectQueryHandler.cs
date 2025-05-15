using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataMgmtModule.Application.Dtos.RecipeDtos;
using DataMgmtModule.Application.Interface.Persistence;
using MediatR;

namespace DataMgmtModule.Application.Feactures.RecipeFeacture.Query.GetrecipeAndProject
{
    public class GetRecipeAndProjectQueryHandler : IRequestHandler<GetRecipeAndProject, IEnumerable<RecipeProjectDTO>>
    {
        private readonly IRecipe _recipeRepository;
        private readonly IMapper _mapper;

        public GetRecipeAndProjectQueryHandler(IRecipe recipeRepository, IMapper mapper)
        {
            _recipeRepository = recipeRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<RecipeProjectDTO>> Handle(GetRecipeAndProject request, CancellationToken cancellationToken)
        {
            var recipeProjectData = await _recipeRepository.GetRecipeAndProjectAsync(request.search);
            return recipeProjectData;
        }
    }
}

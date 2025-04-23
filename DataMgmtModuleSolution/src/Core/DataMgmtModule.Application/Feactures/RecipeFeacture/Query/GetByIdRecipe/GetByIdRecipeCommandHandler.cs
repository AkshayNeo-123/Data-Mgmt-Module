using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataMgmtModule.Application.Dtos.RecipeDtos;
using DataMgmtModule.Application.Interface.Persistence;
using MediatR;

namespace DataMgmtModule.Application.Feactures.RecipeFeacture.Query.GetByIdRecipe
{
    public class GetByIdRecipeCommandHandler:IRequestHandler<GetByIdRecipeCommand, GetAllRecipeDtos>
    {
        private readonly IRecipe _recipeRepository;
        private readonly IMapper _mapper;
        public GetByIdRecipeCommandHandler(IRecipe recipeRepository, IMapper mapper)
        {
            _recipeRepository = recipeRepository;
            _mapper = mapper;
        }
        public async Task<GetAllRecipeDtos> Handle(GetByIdRecipeCommand request, CancellationToken cancellationToken)
        {
            var recipe = await _recipeRepository.RecipeFindById(request.recipeId);
            var result = _mapper.Map<GetAllRecipeDtos>(recipe);
            return result;
        }
    }
    
}

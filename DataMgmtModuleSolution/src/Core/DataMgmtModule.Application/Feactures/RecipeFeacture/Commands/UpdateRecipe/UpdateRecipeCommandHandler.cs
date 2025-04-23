using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataMgmtModule.Application.Interface.Persistence;
using DataMgmtModule.Domain.Entities;
using MediatR;

namespace DataMgmtModule.Application.Feactures.RecipeFeacture.Commands.UpdateRecipe
{
    public class UpdateRecipeCommandHandler:IRequestHandler<UpdateRecipeCommand, int>
    {
        readonly IRecipe _recipeRepository;
        readonly IMapper _mapper;
        public UpdateRecipeCommandHandler(IRecipe recipeRepository, IMapper mapper)
        {
            _recipeRepository = recipeRepository;
            _mapper = mapper;
        }
        public async Task<int> Handle(UpdateRecipeCommand request, CancellationToken cancellationToken)
        {
            var recipe =  _mapper.Map<Recipe>(request.UpdateRecipe);
            var result = await _recipeRepository.UpdateRecipe(request.id, recipe);
            return result;
        }
    }
    
}

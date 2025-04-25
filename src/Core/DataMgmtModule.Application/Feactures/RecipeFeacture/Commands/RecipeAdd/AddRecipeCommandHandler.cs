using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataMgmtModule.Application.Interface.Persistence;
using DataMgmtModule.Domain.Entities;
using MediatR;

namespace DataMgmtModule.Application.Feactures.RecipeFeacture.Commands.RecipeAdd
{
    public class AddRecipeCommandHandler:IRequestHandler<AddRecipeCommand, int>
    {
        private readonly IRecipe _recipe;
        private readonly IMapper _mapper;
        public AddRecipeCommandHandler(IRecipe recipe, IMapper mapper)
        {
            _recipe = recipe;
            _mapper = mapper;
        }
        public async Task<int> Handle(AddRecipeCommand request, CancellationToken cancellationToken)
        {
            var recipe = _mapper.Map<Recipe>(request.recipe.Recipe);
            var result = await _recipe.AddRecipe(recipe,request.userId);
            return result;
        }
    }
    
}

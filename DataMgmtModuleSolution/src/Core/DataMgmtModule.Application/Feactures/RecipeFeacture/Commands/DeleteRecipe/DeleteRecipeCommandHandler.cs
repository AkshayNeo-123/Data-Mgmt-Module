using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Application.Interface.Persistence;
using MediatR;

namespace DataMgmtModule.Application.Feactures.RecipeFeacture.Command.DeleteRecipe
{
    public class DeleteRecipeCommandHandler : IRequestHandler<DeleteRecipeCommand,int>
    {
        private readonly IRecipe _recipeRepository;

        public DeleteRecipeCommandHandler(IRecipe recipeRepository)
        {
            _recipeRepository = recipeRepository;
        }
        public async Task<int> Handle(DeleteRecipeCommand request, CancellationToken cancellationToken)
        {
           return await _recipeRepository.DeleteRecipe(request.recipeId);
            
        }
    }
}

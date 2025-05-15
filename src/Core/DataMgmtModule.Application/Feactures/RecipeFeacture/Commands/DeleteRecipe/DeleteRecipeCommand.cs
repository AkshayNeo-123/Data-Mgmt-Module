using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DataMgmtModule.Application.Feactures.RecipeFeacture.Command.DeleteRecipe
{
    public record DeleteRecipeCommand(int recipeId) : IRequest<int>;
    
}

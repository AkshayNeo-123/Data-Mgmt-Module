using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Application.Dtos.RecipeDtos;
using MediatR;

namespace DataMgmtModule.Application.Feactures.RecipeFeacture.Query.GetByIdRecipe
{
    public record GetByIdRecipeCommand(int recipeId) : IRequest<GetAllRecipeDtos>;
    
}
    

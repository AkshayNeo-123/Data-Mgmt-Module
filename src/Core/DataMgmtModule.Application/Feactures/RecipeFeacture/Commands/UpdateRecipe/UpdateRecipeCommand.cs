using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Application.Dtos.RecipeDtos;
using MediatR;

namespace DataMgmtModule.Application.Feactures.RecipeFeacture.Commands.UpdateRecipe
{
    public record UpdateRecipeCommand(int id, AddRecipe UpdateRecipe,int? userId) :IRequest<int>;
    
}

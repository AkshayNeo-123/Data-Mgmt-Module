using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Application.Dtos.Materials;
using DataMgmtModule.Application.Dtos.RecipeDtos;
using MediatR;

namespace DataMgmtModule.Application.Feactures.RecipeFeacture.Query.GetAllRecipes
{

    public record GetAllRecipesQuery : IRequest<IEnumerable<GetAllRecipeDtos>> { }
}

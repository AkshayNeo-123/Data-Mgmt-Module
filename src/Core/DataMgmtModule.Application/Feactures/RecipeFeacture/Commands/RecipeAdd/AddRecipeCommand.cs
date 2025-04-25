using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using DataMgmtModule.Application.Dtos.RecipeDtos;
using DataMgmtModule.Application.Dtos.CommonDto;

namespace DataMgmtModule.Application.Feactures.RecipeFeacture.Commands.RecipeAdd
{
    public record AddRecipeCommand(RecipeandComponent recipe,int? userId) : IRequest<int>
    {
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Application.Dtos.CommonDto;
using DataMgmtModule.Application.Dtos.RecipeComponentDtos;
using MediatR;

namespace DataMgmtModule.Application.Feactures.RecipeComponentFeactures.Commands.RecipeComponetAdd
{
    public record AddRecipeComponentCommand(int id, RecipeandComponent component,int? userId):IRequest<int>;
    
}

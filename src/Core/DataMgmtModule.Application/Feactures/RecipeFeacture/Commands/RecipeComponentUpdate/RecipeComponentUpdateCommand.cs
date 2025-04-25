using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Application.Dtos.CommonDto;
using DataMgmtModule.Domain.Entities;
using MediatR;

namespace DataMgmtModule.Application.Feactures.RecipeFeacture.Commands.RecipeComponentUpdate
{
    public record RecipeComponentUpdateCommand(int recipeid, RecipeandComponent recipeandComponent,int? userId) :IRequest<int>;

}

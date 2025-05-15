using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Application.Dtos.CommonDto;
using MediatR;

namespace DataMgmtModule.Application.Feactures.RecipeFeacture.Query.GetById
{
    public record GetBIdForUpdateQuery(int recipeId):IRequest<RecipeandComponent>;
}

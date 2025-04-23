using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Application.Models;
using DataMgmtModule.Domain.Entities;
using MediatR;

namespace DataMgmtModule.Application.Feactures.RecipeComponents.Queries.GetAllRecipeComponents
{
    public record GetAllRecipeComponentsQuery() : IRequest<IEnumerable<RecipeComponent>>;
}

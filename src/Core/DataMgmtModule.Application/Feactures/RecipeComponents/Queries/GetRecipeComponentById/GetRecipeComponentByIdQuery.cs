using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Application.Models;
using DataMgmtModule.Domain.Entities;
using MediatR;

namespace DataMgmtModule.Application.Feactures.RecipeComponents.Queries.GetRecipeComponentById
{
    public record GetRecipeComponentByIdQuery(int Id) : IRequest<RecipeComponent>;
}

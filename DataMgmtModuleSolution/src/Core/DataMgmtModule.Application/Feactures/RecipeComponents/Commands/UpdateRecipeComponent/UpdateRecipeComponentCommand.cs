using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Application.Dtos;
using MediatR;

namespace DataMgmtModule.Application.Feactures.RecipeComponents.Commands.UpdateRecipeComponent
{
    public record UpdateRecipeComponentCommand(int Id, UpdateRecipeComponentDto Component) : IRequest<bool>;
}

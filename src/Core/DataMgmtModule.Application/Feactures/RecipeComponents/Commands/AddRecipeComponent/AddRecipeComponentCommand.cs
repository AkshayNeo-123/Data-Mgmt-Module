using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Application.Models;
using DataMgmtModule.Domain.Entities;
using MediatR;

namespace DataMgmtModule.Application.Feactures.RecipeComponents.Commands.AddRecipeComponent
{
    public record AddRecipeComponentCommand(RecipeComponent Component) : IRequest<RecipeComponent>;
}

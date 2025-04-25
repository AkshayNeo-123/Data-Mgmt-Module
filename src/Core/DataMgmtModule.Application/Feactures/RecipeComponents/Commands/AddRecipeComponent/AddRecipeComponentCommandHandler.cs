using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Application.Interface.Persistence;
using DataMgmtModule.Application.Models;
using DataMgmtModule.Domain.Entities;
using MediatR;

namespace DataMgmtModule.Application.Feactures.RecipeComponents.Commands.AddRecipeComponent
{
    public class AddRecipeComponentCommandHandler : IRequestHandler<AddRecipeComponentCommand, RecipeComponent>
    {
        private readonly IRecipeComponent _repository;

        public AddRecipeComponentCommandHandler(IRecipeComponent repository)
        {
            _repository = repository;
        }

        public async Task<RecipeComponent> Handle(AddRecipeComponentCommand request, CancellationToken cancellationToken)
        {
            var created = await _repository.AddAsync(request.Component);
            return created;
        }
    }
}

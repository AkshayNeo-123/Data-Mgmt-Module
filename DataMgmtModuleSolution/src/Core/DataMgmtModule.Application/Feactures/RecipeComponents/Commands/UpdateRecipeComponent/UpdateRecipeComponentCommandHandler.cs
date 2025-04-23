using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Application.Interface.Persistence;
using MediatR;

namespace DataMgmtModule.Application.Feactures.RecipeComponents.Commands.UpdateRecipeComponent
{
    public class UpdateRecipeComponentCommandHandler : IRequestHandler<UpdateRecipeComponentCommand, bool>
    {
        private readonly IRecipeComponent _repository;

        public UpdateRecipeComponentCommandHandler(IRecipeComponent repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(UpdateRecipeComponentCommand request, CancellationToken cancellationToken)
        {
            return await _repository.UpdateAsync(request.Id, request.Component);
        }
    }
}

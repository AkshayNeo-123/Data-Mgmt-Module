using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Application.Interface.Persistence;
using MediatR;

namespace DataMgmtModule.Application.Feactures.RecipeComponents.Commands.DeleteRecipeComponent
{
    public class DeleteRecipeComponentCommandHandler : IRequestHandler<DeleteRecipeComponentCommand, bool>
    {
        private readonly IRecipeComponent _repository;

        public DeleteRecipeComponentCommandHandler(IRecipeComponent repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteRecipeComponentCommand request, CancellationToken cancellationToken)
        {
            return await _repository.DeleteAsync(request.Id);
        }
    }
}

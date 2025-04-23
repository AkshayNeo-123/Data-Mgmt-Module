using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataMgmtModule.Application.Interface.Persistence;
using DataMgmtModule.Domain.Entities;
using MediatR;

namespace DataMgmtModule.Application.Feactures.RecipeComponentFeactures.Commands.RecipeComponetAdd
{
    public class AddRecipeComponentCommandHandler:IRequestHandler<AddRecipeComponentCommand, int>
    {
        private readonly IRecipeComponent _recipeComponent;
        private readonly IMapper _mapper;
        public AddRecipeComponentCommandHandler(IRecipeComponent recipeComponent, IMapper mapper)
        {
            _recipeComponent = recipeComponent;
            _mapper = mapper;
        }
        public async Task<int> Handle(AddRecipeComponentCommand request, CancellationToken cancellationToken)
        {
            //var component = _mapper.Map<RecipeComponent>(request.component);
            int result =0;
            foreach (var item in request.component.Component)
            {
                var component = _mapper.Map<RecipeComponent>(item);
             result = await _recipeComponent.AddRecipeComponent(request.id, component);
                
            }
            return result;
        }
    }
    
}

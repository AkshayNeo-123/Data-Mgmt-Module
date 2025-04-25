using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataMgmtModule.Application.Interface.Persistence;
using DataMgmtModule.Domain.Entities;
using MediatR;

namespace DataMgmtModule.Application.Feactures.RecipeFeacture.Commands.RecipeComponentUpdate
{
    

    public class RecipeComponentUpdateCommandHandler:IRequestHandler<RecipeComponentUpdateCommand, int>
    {
        readonly IRecipe _recipeRepository;
        readonly IMapper _mapper;
        public RecipeComponentUpdateCommandHandler(IRecipe recipeRepository, IMapper mapper)
        {
            _recipeRepository = recipeRepository;
            _mapper = mapper;
        }
        public Task<int> Handle(RecipeComponentUpdateCommand request, CancellationToken cancellationToken)
        {
            var compoent = _mapper.Map<RecipeComponent[]>(request.recipeandComponent.Component);
            return _recipeRepository.UpdateRecipeComponent(request.recipeid, compoent,request.userId);
        }
    }
    
}

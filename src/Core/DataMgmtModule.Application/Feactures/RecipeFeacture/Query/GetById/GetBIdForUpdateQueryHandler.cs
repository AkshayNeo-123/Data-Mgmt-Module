using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataMgmtModule.Application.Dtos.CommonDto;
using DataMgmtModule.Application.Dtos.RecipeComponentDtos;
using DataMgmtModule.Application.Dtos.RecipeDtos;
using DataMgmtModule.Application.Interface.Persistence;
using MediatR;

namespace DataMgmtModule.Application.Feactures.RecipeFeacture.Query.GetById
{
    public class GetBIdForUpdateQueryHandler : IRequestHandler<GetBIdForUpdateQuery, RecipeandComponent>
    {
        readonly IMapper _mapper;
        readonly IRecipe _recipe;
        public GetBIdForUpdateQueryHandler(IMapper mapper, IRecipe recipe)
        {
            
            _mapper = mapper;
            _recipe = recipe;
            
        }
        public async Task<RecipeandComponent> Handle(GetBIdForUpdateQuery request, CancellationToken cancellationToken)
        {
            RecipeandComponent dataGetById= new RecipeandComponent();

            var getRecipe =await _recipe.RecipeFindById(request.recipeId);
            var recipe =  _mapper.Map<AddRecipe>(getRecipe);
            var getComponentsOfRecipe = await _recipe.FindRecipeComponents(request.recipeId);
            if(getComponentsOfRecipe!= null)
            {

            var component = _mapper.Map<AddRecipeComponentDto[]>(getComponentsOfRecipe);
            dataGetById.Component = component;
            }
            dataGetById.Recipe=recipe;
            
            return dataGetById;
            






        }
    }
}

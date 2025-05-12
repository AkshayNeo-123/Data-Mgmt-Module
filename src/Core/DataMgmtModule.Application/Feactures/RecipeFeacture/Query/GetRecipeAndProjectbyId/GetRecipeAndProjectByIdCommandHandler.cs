using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataMgmtModule.Application.Dtos.RecipeDtos;
using DataMgmtModule.Application.Exceptions;
using DataMgmtModule.Application.Interface.Persistence;
using MediatR;

namespace DataMgmtModule.Application.Feactures.RecipeFeacture.Query.GetRecipeAndProjectbyId
{
    public class GetRecipeAndProjectByIdCommandHandler : IRequestHandler<GetRecipeAndProjectByIdCommand, RecipeProjectDTO>
    {
        private readonly IRecipe _recipeRepository;
        private readonly IMapper _mapper;

        public GetRecipeAndProjectByIdCommandHandler(IRecipe recipeRepository, IMapper mapper)
        {
            _recipeRepository = recipeRepository;
            _mapper = mapper;
        }
        public async Task<RecipeProjectDTO> Handle(GetRecipeAndProjectByIdCommand request, CancellationToken cancellationToken)
        {
            var getData = await _recipeRepository.GetRecipeProjectById(request.id);
            if (getData == null)
            {
                throw new NotFoundException("RecipeProject Data not found");
            }
            return getData;

        }
    }
}

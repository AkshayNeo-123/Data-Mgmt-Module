using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataMgmtModule.Application.Dtos.TestDtos;
using DataMgmtModule.Application.Interface.Persistence;
using MediatR;

namespace DataMgmtModule.Application.Feactures.TestFeactures.Query.GetTestByRecipe
{
    public class GetTestByRecipeQueryHandler : IRequestHandler<GetTestByRecipeQuery, CommonTestDto>
    {
        private readonly IMapper _mapper;
        private readonly IRecipe _recipe;
        public GetTestByRecipeQueryHandler(IMapper mapper,IRecipe recipe)
        {
            _mapper= mapper;
            _recipe= recipe;
        }
        public Task<CommonTestDto> Handle(GetTestByRecipeQuery request, CancellationToken cancellationToken)
        {
            var getRecipe = _recipe.GetTestPropertiesByRecipe(request.id);
            if (getRecipe == null)
            {
                throw new Exception($"Data with id{request.id}not found ");
            }
            return getRecipe;
        }
    }
}

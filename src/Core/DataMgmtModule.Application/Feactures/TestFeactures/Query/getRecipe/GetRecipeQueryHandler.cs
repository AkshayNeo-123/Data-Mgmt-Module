using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataMgmtModule.Application.Dtos.TestDtos;
using DataMgmtModule.Application.Interface.Persistence;
using MediatR;

namespace DataMgmtModule.Application.Feactures.TestFeactures.Query.getRecipe
{
    public class GetRecipeQueryHandler : IRequestHandler<GetRecipeQuery, IEnumerable<GetRecipeForTestDto>>
    {
        readonly ITestRepository _testRepository;
        readonly IMapper _mapper;
        public GetRecipeQueryHandler(ITestRepository testRepository, IMapper mapper)
        {
            _testRepository= testRepository;
            _mapper= mapper;
        }
        public async Task<IEnumerable<GetRecipeForTestDto>> Handle(GetRecipeQuery request, CancellationToken cancellationToken)
        {
            var recipes = await _testRepository.GetRecipedataForAddTest();
            var mapdata = _mapper.Map<IEnumerable<GetRecipeForTestDto>>(recipes);
            return mapdata;
        }
    }
}

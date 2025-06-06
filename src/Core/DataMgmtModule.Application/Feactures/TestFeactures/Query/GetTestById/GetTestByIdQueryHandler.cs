using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataMgmtModule.Application.Dtos.TestDtos;
using DataMgmtModule.Application.Interface.Persistence;
using MediatR;

namespace DataMgmtModule.Application.Feactures.TestFeactures.Query.GetTestById
{
    public class GetTestByIdQueryHandler : IRequestHandler<GetTestByIdQuery, UpdateTestDto>
    {
        private readonly ITestRepository _testRepository;
        readonly IMapper _mapper;

        public GetTestByIdQueryHandler(ITestRepository testRepository, IMapper mapper)
        {
            _testRepository = testRepository;
            _mapper = mapper;
        }

        public async Task<UpdateTestDto> Handle(GetTestByIdQuery request, CancellationToken cancellationToken)
        {
            var testdetails = await _testRepository.GetTestById(request.testId);
            var mapdata = _mapper.Map<UpdateTestDto>(testdetails);
            return mapdata;
        }

    }
}

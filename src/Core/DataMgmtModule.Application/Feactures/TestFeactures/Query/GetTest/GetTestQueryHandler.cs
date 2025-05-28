using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataMgmtModule.Application.Dtos.TestDtos;
using DataMgmtModule.Application.Interface.Persistence;
using MediatR;

namespace DataMgmtModule.Application.Feactures.TestFeactures.Query.GetTest
{
    public class GetTestQueryHandler : IRequestHandler<GetTestQuery, IEnumerable<TestDto>>
    {
        readonly ITestRepository _repository;
        readonly IMapper _mapper;
        public GetTestQueryHandler(ITestRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<TestDto>> Handle(GetTestQuery request, CancellationToken cancellationToken)
        {
            var testData = await _repository.GetTest();
            var mapdata= _mapper.Map<IEnumerable<TestDto>>(testData);
            return mapdata;
        }
    }
}

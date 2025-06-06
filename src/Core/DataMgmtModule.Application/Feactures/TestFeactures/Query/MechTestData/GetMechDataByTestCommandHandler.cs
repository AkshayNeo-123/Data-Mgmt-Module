using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataMgmtModule.Application.Dtos.TestDtos;
using DataMgmtModule.Application.Interface.Persistence;
using MediatR;

namespace DataMgmtModule.Application.Feactures.TestFeactures.Query.MechTestData
{
    public class GetMechDataByTestCommandHandler : IRequestHandler<GetMechPropertyDataByTestCommand, MechanicalPropertyDto>
    {
        private readonly IMapper _mapper;
        private readonly ITestRepository _testRepo;
        public GetMechDataByTestCommandHandler(IMapper mapper, ITestRepository testRepository)
        {
            _mapper = mapper;
            _testRepo =testRepository;
        }
        public async Task<MechanicalPropertyDto> Handle(GetMechPropertyDataByTestCommand request, CancellationToken cancellationToken)
        {
            var getMechdata = await _testRepo.GetMechPropertyByTest(request.testId);
            
            var mapMechProperty = _mapper.Map<MechanicalPropertyDto>(getMechdata);
            return mapMechProperty;
        }
    }
}

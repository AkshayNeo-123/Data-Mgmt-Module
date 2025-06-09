using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataMgmtModule.Application.Dtos.TestDtos;
using DataMgmtModule.Application.Interface.Persistence;
using DataMgmtModule.Domain.Entities;
using MediatR;

namespace DataMgmtModule.Application.Feactures.TestFeactures.Query.GetTestDataForExport
{
    public class GetTestDataForExportQueryHandler : IRequestHandler<GetTestDataForExportQuery, IEnumerable<ExportTestDataDto>>
    {
        readonly ITestRepository _repository;
        readonly IMapper _mapper;
        public GetTestDataForExportQueryHandler(ITestRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ExportTestDataDto>> Handle(GetTestDataForExportQuery request, CancellationToken cancellationToken)
        {
            var test= await _repository.GetTestForExport();
            var mapdata = _mapper.Map<IEnumerable<ExportTestDataDto>>(test);
            return mapdata;
        }
    }
}

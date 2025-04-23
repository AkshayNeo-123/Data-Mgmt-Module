using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataMgmtModule.Application.Dtos.CommonDtos;
using DataMgmtModule.Application.Interface.Persistence;
using DataMgmtModule.Domain.Entities;
using MediatR;

namespace DataMgmtModule.Application.Feactures.CompoundingDatas.Command.UpdateCompoundingData
{
    public class UpdateCompoundingDataCommandHandler : IRequestHandler<UpdateCompoundingCommand, int>
    {
        private readonly ICompoundingData _compoundingData;
        private readonly IMapper _mapper;

        public UpdateCompoundingDataCommandHandler(ICompoundingData compoundingData,IMapper mapper)
        {
            _compoundingData= compoundingData;
            _mapper= mapper;
        }

        public async Task<int> Handle(UpdateCompoundingCommand request, CancellationToken cancellationToken)
        {

            var addData = _mapper.Map<CompoundingDatum>(request.compoundingDataDTO);
            var updateData = await _compoundingData.UpdateCompoundingDataAsync(request.id, addData);
            return updateData;
        }
    }
}

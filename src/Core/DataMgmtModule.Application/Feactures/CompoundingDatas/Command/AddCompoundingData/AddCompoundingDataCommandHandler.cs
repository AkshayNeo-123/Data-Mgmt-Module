using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataMgmtModule.Application.Interface.Persistence;
using DataMgmtModule.Domain.Entities;
using MediatR;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DataMgmtModule.Application.Feactures.CompoundingDatas.Command.AddCompoundingData
{
    public class AddCompoundingDataCommandHandler : IRequestHandler<AddCompoundingCommand, int>
    {
        private readonly ICompoundingData _compoundingData;
        private readonly IMapper _mapper;

        public AddCompoundingDataCommandHandler(ICompoundingData compoundingData, IMapper mapper)
        {
            _compoundingData = compoundingData;
            _mapper = mapper;
        }
        public async Task<int> Handle(AddCompoundingCommand request, CancellationToken cancellationToken)
        {
            var addData = _mapper.Map<CompoundingDatum>(request. compoundingDataDTO.CompoundingDataDTO);

            addData.RecipeId = request.compoundingDataDTO.CompoundingDataDTO.ReceipeId;

            var data = await _compoundingData.AddCompoundingData(addData,request.userId);
            return data;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataMgmtModule.Application.Dtos;
using DataMgmtModule.Application.Dtos.CommonDtos;
using DataMgmtModule.Application.Dtos.Dosage;
using DataMgmtModule.Application.Interface.Persistence;
using DataMgmtModule.Domain.Entities;
using MediatR;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DataMgmtModule.Application.Feactures.CompoundingDatas.Query.GetDataByIdcompoundingQuery
{
    public class GetDataByIdcompoundingQueryHandler : IRequestHandler<GetDataByIdcompoundingQuery, CompoundingDataAndComponents>
    {
        private readonly ICompoundingData _compoundingData;
        readonly ICompoundingComponentsRepository _compoundingComponentsRepository;
        readonly IDosageRepository _dosageRepository; 
        readonly IMapper _mapper;
        public GetDataByIdcompoundingQueryHandler(ICompoundingData compoundingData, IMapper mapper, ICompoundingComponentsRepository compoundingComponentsRepository, IDosageRepository dosageRepository)
        {
            _compoundingData = compoundingData;
            _mapper = mapper;
            _compoundingComponentsRepository = compoundingComponentsRepository;
            _dosageRepository = dosageRepository;
        }

        public async Task<CompoundingDataAndComponents> Handle(GetDataByIdcompoundingQuery request, CancellationToken cancellationToken)
        {
            CompoundingDataAndComponents alldata = new CompoundingDataAndComponents();
            var getData = await _compoundingData.GetCompoundingDataAsync(request.Id);
            var componentdata =await _compoundingComponentsRepository.GetCompoundingComponentsBycompoundingId(request.Id);
            var compoundingdata=_mapper.Map<CompoundingDataDTO >(getData);
            var dosagedata = await _dosageRepository.getDosagebyCompoundingId(request.Id);
            var dosagedrto = _mapper.Map<DosageDTO>(dosagedata);
            var compoentArray = _mapper.Map<CompoundingComponentsDTO[]>(componentdata);
            alldata.CompoundingDataDTO = compoundingdata;
            alldata.CompoundingDataDTO.ReceipeId = getData.RecipeId.Value;
            alldata.Components = compoentArray;
            alldata.DosageDTO = dosagedrto;
            return alldata;



            //return getData;
        }
        //public Task<CompoundingData> Handle(GetCompoundDataByQuery request, CancellationToken cancellationToken)
        //{
        //    var getData=_
        //}
    }
}

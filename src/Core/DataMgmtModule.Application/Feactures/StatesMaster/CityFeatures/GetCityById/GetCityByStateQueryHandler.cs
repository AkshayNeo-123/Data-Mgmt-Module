using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataMgmtModule.Application.Dtos.CityDTO;
using DataMgmtModule.Application.Interface.Persistence;
using DataMgmtModule.Domain.Entities;
using MediatR;

namespace DataMgmtModule.Application.Feactures.StatesMaster.CityFeatures.GetCityById
{
    public class GetCityByStateQueryHandler : IRequestHandler<GetCityByStateQuery, IEnumerable<CitiesDTO>>
    {
        private readonly IStateRepository _stateRepository;
        private readonly IMapper _mapper;
        public GetCityByStateQueryHandler(IStateRepository stateRepository,IMapper mapper)
        {
            _stateRepository = stateRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CitiesDTO>> Handle(GetCityByStateQuery request, CancellationToken cancellationToken)
        {
            var getDataByState = await _stateRepository.GetCitiesByStateAsync(request.Id);
            var mapData = _mapper.Map<IEnumerable<CitiesDTO>>(getDataByState);
            return mapData;
        }
    }
}

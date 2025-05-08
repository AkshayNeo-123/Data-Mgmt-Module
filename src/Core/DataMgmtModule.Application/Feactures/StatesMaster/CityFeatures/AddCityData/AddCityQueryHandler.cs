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

namespace DataMgmtModule.Application.Feactures.StatesMaster.CityFeatures.AddCityData
{
    public class AddCityQueryHandler : IRequestHandler<AddCityQuery, AddCityDTO>
    {
        private readonly IStateRepository _stateRepository;
        private readonly IMapper _mapper;
        public AddCityQueryHandler(IStateRepository stateRepository, IMapper mapper)
        {
            _stateRepository = stateRepository;
            _mapper = mapper;
        }
        public async Task<AddCityDTO> Handle(AddCityQuery request, CancellationToken cancellationToken)
        {
            var mapCity = _mapper.Map<Cities>(request.addCityDTO);
            var addCity = await _stateRepository.AddCityAsync(mapCity);
            var resultDto = _mapper.Map<AddCityDTO>(addCity);
            return resultDto;
        }
    }
}

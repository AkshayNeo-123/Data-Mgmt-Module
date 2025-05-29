using System;
using System.Collections.Generic;
using System.Data;
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
        readonly IFlammabilityPropertiesRepository _flammabilityPropertiesRepository;
        readonly ITemperaturePropertyRepository _temperaturePropertyRepository;
        readonly IPropertyRepository _propertyRepository;
        readonly IElectricalPropertiesRepository _electricalPropertiesRepository;
        readonly IGeneralPropertiesRepository _generalPropertiesRepository;
        readonly IMechanicalPropertyRepository _mechanicalPropertyRepository;
        public GetTestQueryHandler(IMechanicalPropertyRepository mechanicalPropertyRepository,IGeneralPropertiesRepository generalPropertiesRepository,IElectricalPropertiesRepository electricalPropertiesRepository,IPropertyRepository propertyRepository,ITestRepository repository, IMapper mapper, IFlammabilityPropertiesRepository flammabilityPropertiesRepository, ITemperaturePropertyRepository temperaturePropertyRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _flammabilityPropertiesRepository = flammabilityPropertiesRepository;
            _temperaturePropertyRepository = temperaturePropertyRepository;
            _propertyRepository= propertyRepository;
            _electricalPropertiesRepository = electricalPropertiesRepository;
            _generalPropertiesRepository = generalPropertiesRepository;
            _mechanicalPropertyRepository = mechanicalPropertyRepository;

            
        }
        public async Task<IEnumerable<TestDto>> Handle(GetTestQuery request, CancellationToken cancellationToken)
        {
            var testData = await _repository.GetTest();
            var mapdata= _mapper.Map<IEnumerable<TestDto>>(testData);
            foreach(var item in mapdata)
            {
                var flammabilityPropertiesdata = await _flammabilityPropertiesRepository.GetByTestId(item.Id);
                if (flammabilityPropertiesdata != null)
                {
                    item.FlammabilityProperties = true;
                }

                var temperaturePropertydata = await _temperaturePropertyRepository.GetByTestId(item.Id);
                if (temperaturePropertydata!=null)
                {
                    item.TemperatureProperties = true;
                }

                var propertydata = await _propertyRepository.GetByTestId(item.Id);
                if (propertydata != null)
                {
                    item.Property = true;
                }

                var ElectricalPropertiesdata = await _electricalPropertiesRepository.GetByTestId(item.Id);
                if (ElectricalPropertiesdata != null)
                {
                    item.ElectricalProperties = true;
                }
                var generalPropertiesdata = await _generalPropertiesRepository.GetByTestId(item.Id);
                if (generalPropertiesdata != null)
                {
                    item.GeneralProperties = true;
                }
                var mechanicalPropertydata = await _mechanicalPropertyRepository.GetByTestId(item.Id);
                if (mechanicalPropertydata != null)
                {
                    item.MechanicalProperty = true;
                }



            }
            return mapdata;
        }
    }
}
   
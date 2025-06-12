using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataMgmtModule.Application.Dtos.TestDtos;
using DataMgmtModule.Application.Interface.Persistence;
using MediatR;

namespace DataMgmtModule.Application.Feactures.TestFeactures.Query.GetTestByRecipe
{
    public class GetTestByRecipeQueryHandler : IRequestHandler<GetTestByRecipeQuery, CommonTestDto>
    {
        private readonly IMapper _mapper;
        private readonly IRecipe _recipe;
        private readonly IMechanicalPropertyRepository _mechanicalPropertyRepository;
        private readonly IElectricalPropertiesRepository _electricalPropertiesRepository;
        private readonly ITemperaturePropertyRepository _temperaturePropertyRepository;
        private readonly IGeneralPropertiesRepository _generalPropertiesRepository;
        private readonly IPropertyRepository _propertyRepository;
        private readonly IFlammabilityPropertiesRepository _flammabilityPropertiesRepository;

        public GetTestByRecipeQueryHandler(IMapper mapper,IRecipe recipe,IMechanicalPropertyRepository mechanicalPropertyRepository,
            IElectricalPropertiesRepository electricalPropertiesRepository,ITemperaturePropertyRepository temperaturePropertyRepository
            ,IGeneralPropertiesRepository generalPropertiesRepository,IPropertyRepository propertyRepository,IFlammabilityPropertiesRepository flammabilityPropertiesRepository)
        {
            _mapper= mapper;
            _recipe= recipe;
            _mechanicalPropertyRepository = mechanicalPropertyRepository;
            _electricalPropertiesRepository = electricalPropertiesRepository;
            _temperaturePropertyRepository = temperaturePropertyRepository;
            _generalPropertiesRepository = generalPropertiesRepository;
            _propertyRepository = propertyRepository;
            _flammabilityPropertiesRepository = flammabilityPropertiesRepository;


        }
        public async Task<CommonTestDto> Handle(GetTestByRecipeQuery request, CancellationToken cancellationToken)
        {
            var getRecipe =await _recipe.GetTestByRecipe(request.id);
            if (getRecipe == null)
            {
                throw new Exception($"Data with id{request.id}not found ");
            }
            var testDto = _mapper.Map<CommonTestDto>(getRecipe);

            var mech = await _mechanicalPropertyRepository.GetByTestId(getRecipe.Id);
            if (mech != null)
            {
                testDto.MechanicalPropertyDto = _mapper.Map<MechanicalPropertyDto>(mech);
            }
            var electticalPro = await _electricalPropertiesRepository.GetByTestId(getRecipe.Id);

            if (electticalPro != null)
            {
                testDto.ElectricalPropertyDto = _mapper.Map<ElectricalPropertyDto>(electticalPro);
            }
            var tempProperty = await _temperaturePropertyRepository.GetByTestId(getRecipe.Id);
            if (tempProperty != null)
            {
                testDto.TemperaturePropertyDto = _mapper.Map<TemperaturePropertyDto>(tempProperty);
            }
            var generalProperty = await _generalPropertiesRepository.GetByTestId(getRecipe.Id);
            if (generalProperty != null)
            {
                testDto.GeneralPropertyDto = _mapper.Map<GeneralPropertyDto>(generalProperty);
            }

            var properties = await _propertyRepository.GetByTestId(getRecipe.Id);
            if (properties != null)
            {
                testDto.PropertiesDto = _mapper.Map<PropertiesDto>(properties);
            }
            var flam = await _flammabilityPropertiesRepository.GetByTestId(getRecipe.Id);
            if (flam != null)
                testDto.FlammabilityPropertyDto = _mapper.Map<FlammabilityPropertyDto>(flam);

            return testDto;
        }
    }
}

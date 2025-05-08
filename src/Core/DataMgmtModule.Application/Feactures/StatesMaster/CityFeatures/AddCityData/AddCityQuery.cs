using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Application.Dtos.CityDTO;
using MediatR;

namespace DataMgmtModule.Application.Feactures.StatesMaster.CityFeatures.AddCityData
{
    public record AddCityQuery(AddCityDTO addCityDTO):IRequest<AddCityDTO>
    {
    }
}

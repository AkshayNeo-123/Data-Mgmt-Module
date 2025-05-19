using DataMgmtModule.Application.Dtos.CityDTO;
using DataMgmtModule.Application.Feactures.StatesMaster.CityFeatures.AddCityData;
using DataMgmtModule.Application.Feactures.StatesMaster.CityFeatures.GetCityById;
using DataMgmtModule.Application.Feactures.StatesMaster.StateFeatures.AddStateData;
using DataMgmtModule.Application.Feactures.StatesMaster.StateFeatures.GetAllStates;
using DataMgmtModule.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DataMgmtModule.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatesController : ControllerBase
    {

        private readonly IMediator _mediator;

        public StatesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("states")]
        public async Task<ActionResult<List<States>>> GetAllStatesAsync()
        {
            var getStates = await _mediator.Send(new GetALlStatesQuery());
            return Ok(getStates);
        }


        [HttpGet("cities")]
        public async Task<ActionResult<List<Cities>>> GetAllCitiesAsync(int id)
        {
            var getCities = await _mediator.Send(new GetCityByStateQuery(id));
            return Ok(getCities);
        }

        [HttpPost("addCities")]
        public async Task<ActionResult>AddCitiesAsync(string cityName,int stateId)
        {
            var addCities=await _mediator.Send(new AddCityQuery(cityName,stateId));
            return Ok(addCities);
        }
        [HttpPost("addState")]

        public async Task<ActionResult>AddStatesAsync(States states)
        {
            var addStates = await _mediator.Send(new AddStateQuery(states));
            return Ok(addStates);
        }

    }
}

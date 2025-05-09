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


        //[HttpGet("cities")]
        //public async Task<ActionResult<List<Cities>>> GetAllCitiesAsync()
        //{
        //    var getCities = await _mediator.Send(new GetAllCityQuery());
        //    return Ok(getCities);
        //}

    }
}

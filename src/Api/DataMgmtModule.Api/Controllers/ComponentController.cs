using DataMgmtModule.Application.Features.Components.Queries.GetAll;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DataMgmtModule.Api.Controllers.v1
{
    [ApiController]
    [Route("api/[controller]")]

    public class ComponentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ComponentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllComponentsQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}

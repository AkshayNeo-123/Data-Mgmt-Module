using DataMgmtModule.Application.Feactures.ProjectTypeFeactures.Query.GetAllPriorities;
using DataMgmtModule.Application.Feactures.ProjectTypeFeactures.Query.GetAllProjectTypes;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DataMgmtModule.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrioritiesController : ControllerBase
    {
        readonly IMediator _mediator;
        public PrioritiesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAllPriorities")]
        public async Task<IActionResult> GetAllPriorities()
        {
            var result = await _mediator.Send(new GetAllPrioritiesQuery());
            return Ok(result);
        }
    }
}

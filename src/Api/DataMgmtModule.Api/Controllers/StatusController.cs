using DataMgmtModule.Application.Feactures.ProjectTypeFeactures.Query.GetAllProjectTypes;
using DataMgmtModule.Application.Feactures.ProjectTypeFeactures.Query.GetAllStatus;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DataMgmtModule.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        readonly IMediator _mediator;
        public StatusController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAllStatus")]
        public async Task<IActionResult> GetAllStatus()
        {
            var result = await _mediator.Send(new GetAllStatusQuery());
            return Ok(result);
        }
    }
}

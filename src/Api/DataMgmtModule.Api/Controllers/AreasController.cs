using DataMgmtModule.Application.Feactures.ProjectTypeFeactures.Query.GetAllAreas;
using DataMgmtModule.Application.Feactures.ProjectTypeFeactures.Query.GetAllProjectTypes;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DataMgmtModule.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreasController : ControllerBase
    {
        readonly IMediator _mediator;
        public AreasController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAllAreas")]
        public async Task<IActionResult> GetAllAreas()
        {
            var result = await _mediator.Send(new GetAllAreasQuery());
            return Ok(result);
        }
    }
}

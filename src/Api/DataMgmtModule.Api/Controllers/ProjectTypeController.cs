using DataMgmtModule.Application.Feactures.ProjectsFeactures.Query.GetAllProjects;
using DataMgmtModule.Application.Feactures.ProjectTypeFeactures.Query.GetAllProjectTypes;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DataMgmtModule.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectTypeController : ControllerBase
    {
        readonly IMediator _mediator;
        public ProjectTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAllProjectTypes")]
        public async Task<IActionResult> GetAllProjectType()
        {
            var result = await _mediator.Send(new GetAllProjectTypesQuery());
            return Ok(result);
        }
    }
}

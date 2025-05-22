using DataMgmtModule.Application.Dtos.MainPolymerDtos;
using DataMgmtModule.Application.Feactures.MainPolymerFeatures.Command.AddMainPolymer;
using DataMgmtModule.Application.Feactures.MainPolymerFeatures.Command.DeleteMainPolymer;
using DataMgmtModule.Application.Feactures.MainPolymerFeatures.Command.UpdateMainPolymer;
using DataMgmtModule.Application.Feactures.MainPolymerFeatures.Query.GetAllMainPolymers;
using DataMgmtModule.Application.Feactures.MainPolymerFeatures.Query.GetMainPolymerById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DataMgmtModule.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainPolymerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MainPolymerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _mediator.Send(new GetAllMainPolymersQuery()));

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var polymer = await _mediator.Send(new GetMainPolymerByIdQuery(id));
            return polymer == null ? NotFound() : Ok(polymer);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateMainPolymerDto dto)
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            var result = await _mediator.Send(new AddMainPolymerCommand(dto,userId));
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateMainPolymerDto dto)
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            var success = await _mediator.Send(new UpdateMainPolymerCommand(id, dto,userId));
            return success ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id,int deletedBy)
        {
            var success = await _mediator.Send(new DeleteMainPolymerCommand(id,deletedBy));
            return success ? NoContent() : NotFound();
        }
    }
}

using DataMgmtModule.Application.Dtos.AdditiveDtos;
using DataMgmtModule.Application.Feactures.AdditiveFeatures.Command.AddAdditive;
using DataMgmtModule.Application.Feactures.AdditiveFeatures.Command.DeleteAdditive;
using DataMgmtModule.Application.Feactures.AdditiveFeatures.Command.UpdateAdditive;
using DataMgmtModule.Application.Feactures.AdditiveFeatures.Query.GetAdditiveById;
using DataMgmtModule.Application.Feactures.AdditiveFeatures.Query.GetAllAdditives;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DataMgmtModule.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdditiveController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AdditiveController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllAdditivesQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetAdditiveByIdQuery(id));
            return result == null ? NotFound() : Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAdditiveDto dto)
        {
            int? userId = HttpContext.Session.GetInt32("UserId");

            var result = await _mediator.Send(new AddAdditiveCommand(dto,userId));
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateAdditiveDto dto)
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            var success = await _mediator.Send(new UpdateAdditiveCommand(id, dto,userId));
            return success ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id,int deletedBy)
        {
            var success = await _mediator.Send(new DeleteAdditiveCommand(id,deletedBy));
            return success ? NoContent() : NotFound();
        }
    }
}

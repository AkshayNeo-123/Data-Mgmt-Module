using DataMgmtModule.Application.Dtos.Materials;
using DataMgmtModule.Application.Feactures.Materials.Command.AddMaterials;
using DataMgmtModule.Application.Feactures.Materials.Command.DeleteMaterials;
using DataMgmtModule.Application.Feactures.Materials.Command.UpdateMaterials;
using DataMgmtModule.Application.Feactures.Materials.Query.GetAllMaterials;
using DataMgmtModule.Application.Feactures.Materials.Query.GetMaterialById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DataMgmtModule.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialsController : Controller
    {
        private readonly IMediator _mediator;

        public MaterialsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetMaterials")]
        public async Task<ActionResult> GetAllMaterials()
        {
            var materials = await _mediator.Send(new GetAllMaterialsQuery());
            return Ok(materials);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMaterial(int id)
        {
            await _mediator.Send(new DeleteMaterialsCommand(id));
            return Ok($"Material with ID {id} has been deleted.");
        }

        [HttpPost("AddMaterials")]
        public async Task<IActionResult> AddMaterials([FromBody] AddMaterialsDto materialDto)
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            var command = new AddMaterialsCommand(materialDto, userId);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("UpdateMaterials/{id}")]
        public async Task<IActionResult> UpdateMaterial(int id, [FromBody] UpdateMaterialsDto materialDto)
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            await _mediator.Send(new UpdateMaterialsCommand { Id = id, MaterialDto = materialDto,UserId=userId });
            return Ok(new { Message = $"Materials with ID {id} updated successfully." });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMaterialById(int id)
        {
            var material = await _mediator.Send(new GetMaterialByIdQyery(id));
            return Ok(material);
        }

    }
}

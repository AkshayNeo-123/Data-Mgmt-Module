using DataMgmtModule.Application.Dtos.InjectionMolding;
using DataMgmtModule.Application.Dtos.RecipeDtos;
using DataMgmtModule.Application.Feactures.InjectionMolding.Command.UpdateInjectionModling;
using DataMgmtModule.Application.Feactures.InjectionMolding.Query.GetAllInjectionMolding;
using DataMgmtModule.Application.Feactures.InjectionMolding.Query.GetByIdInjectionMolding;
using DataMgmtModule.Application.Feactures.Materials.Query.GetMaterialById;
using DataMgmtModule.Application.Feactures.RecipeFeacture.Query.GetAllRecipes;
using DataMgmtModule.Application.Features.InjectionMolding.Command.DeleteInjectionModling;
using DataMgmtModule.InjectionMoldingInjectionMolding.InjectionMolding;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DataMgmtModule.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InjectionModling : ControllerBase
    {
        private readonly IMediator _mediator;

        public InjectionModling(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<InjectionMoldingDto>>> GetAllInjectionModling()
        {
            var injectionmodling = await _mediator.Send(new GetAllInjectionMoldingQuery());
            return Ok(injectionmodling);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteInjectionMolding(int recipeId)
        {
            var result = await _mediator.Send(new DeleteInjectionModlingCommand(recipeId));

            if (result == 0)
                return NotFound($"Injection Molding record with ID {recipeId} not found.");

            return Ok($"Injection Molding record with ID {recipeId} deleted successfully.");
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateInjectionMolding(int id,[FromBody] UpdateInjectionMoldingDto injectionMoldingDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var command =_mediator.Send( new UpdateInjectionModlingCommand(id,injectionMoldingDto));

          

            return Ok(new { message = "Injection Molding updated successfully", affectedRows = command });
        }

        [HttpGet]
        public async Task<IActionResult> GetInjectionMoldingById(int recipeId)
        {
            var material = await _mediator.Send(new GetByIdInjectionMoldingQuery(recipeId));
            return Ok(material);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddInjectionMoldingDto dto)
        {
            var command = new CreateInjectionMoldingCommand(dto);
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}

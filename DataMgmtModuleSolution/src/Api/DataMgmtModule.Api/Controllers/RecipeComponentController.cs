using DataMgmtModule.Application.Dtos;
using DataMgmtModule.Application.Feactures.RecipeComponents.Commands.AddRecipeComponent;
using DataMgmtModule.Application.Feactures.RecipeComponents.Commands.DeleteRecipeComponent;
using DataMgmtModule.Application.Feactures.RecipeComponents.Commands.UpdateRecipeComponent;
using DataMgmtModule.Application.Feactures.RecipeComponents.Queries.GetAllRecipeComponents;
using DataMgmtModule.Application.Feactures.RecipeComponents.Queries.GetRecipeComponentById;
using DataMgmtModule.Application.Models;
using DataMgmtModule.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DataMgmtModule.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeComponentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RecipeComponentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _mediator.Send(new GetAllRecipeComponentsQuery()));

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _mediator.Send(new GetRecipeComponentByIdQuery(id));
            return item == null ? NotFound() : Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Add(RecipeComponent rc) =>
            Ok(await _mediator.Send(new AddRecipeComponentCommand(rc)));

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateRecipeComponentDto dto) =>
            (await _mediator.Send(new UpdateRecipeComponentCommand(id, dto))) ? NoContent() : NotFound();

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) =>
            (await _mediator.Send(new DeleteRecipeComponentCommand(id))) ? NoContent() : NotFound();
    }
}

using DataMgmtModule.Application.Dtos.RecipeComponentTypeDto;
using MediatR;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class RecipeComponentTypeController : ControllerBase
{
    private readonly IMediator _mediator;

    public RecipeComponentTypeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<RecipeComponentTypeDto>>> Get()
    {
        var result = await _mediator.Send(new GetAllRecipeComponentTypesQuery());
        return Ok(result);
    }
}

using DataMgmtModule.Application.Dtos.CommonDto;
using DataMgmtModule.Application.Dtos.RecipeComponentDtos;
using DataMgmtModule.Application.Dtos.RecipeDtos;
using DataMgmtModule.Application.Feactures.CompoundingComponentsDatas.Command.DeleteCompoundingComponents;
using DataMgmtModule.Application.Feactures.RecipeComponentFeactures.Commands.RecipeComponetAdd;
using DataMgmtModule.Application.Feactures.RecipeFeacture.Command.DeleteRecipe;
using DataMgmtModule.Application.Feactures.RecipeFeacture.Commands.RecipeAdd;
using DataMgmtModule.Application.Feactures.RecipeFeacture.Commands.RecipeComponentUpdate;
using DataMgmtModule.Application.Feactures.RecipeFeacture.Commands.UpdateRecipe;
using DataMgmtModule.Application.Feactures.RecipeFeacture.Query.GetAllRecipes;
using DataMgmtModule.Application.Feactures.RecipeFeacture.Query.GetByIdRecipe;
using DataMgmtModule.Application.Features.InjectionMolding.Command.DeleteInjectionModling;
using DataMgmtModule.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DataMgmtModule.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        readonly IMediator _mediator;
        public RecipeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("AddRecipe")]
        public async Task<IActionResult> AddRecipe([FromBody] RecipeandComponent recipeandComponent)
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            if (recipeandComponent == null)
            {
                return BadRequest("Invalid recipe data.");
            }
            var result = await _mediator.Send(new AddRecipeCommand(recipeandComponent,userId));
            var component = await _mediator.Send(new AddRecipeComponentCommand(result, recipeandComponent,userId));

            return Ok(new { Message = "Recipe added successfully!", RecipeId = result });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            await _mediator.Send(new DeleteRecipeCommand(id,userId));
            await _mediator.Send(new DeleteCompoundingComponentCommand(id,userId));
            var result = await _mediator.Send(new DeleteInjectionModlingCommand(id,userId));

            return Ok();
        }

        [HttpPut("UpdateRecipeandComponent")]
        public async Task<IActionResult> UpdateRecipe(int id, RecipeandComponent updateRecipeDto)
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            if (updateRecipeDto == null)
            {
                return BadRequest("Invalid recipe data.");
            }
            var result = await _mediator.Send(new UpdateRecipeCommand(id,updateRecipeDto.Recipe,userId));
            var updateComponent = await _mediator.Send(new RecipeComponentUpdateCommand(id, updateRecipeDto,userId));

            return Ok(new { Message = "Recipe updated successfully!", RecipeId = result });
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<GetAllRecipeDtos>>> GetAllRecipes()
        {
            var recipes = await _mediator.Send(new GetAllRecipesQuery());
            return Ok(recipes);
        }

        [HttpGet("GetById")]
        public async Task<ActionResult<GetAllRecipeDtos>> GetById(int recipeId)
        {
            var recipes = await _mediator.Send(new GetByIdRecipeCommand(recipeId));
            return Ok(recipes);
        }


    }
}

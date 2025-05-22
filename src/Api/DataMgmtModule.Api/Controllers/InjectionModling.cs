using DataMgmtModule.Application.Dtos.InjectionMolding;
using DataMgmtModule.Application.Dtos.RecipeDtos;
using DataMgmtModule.Application.Feactures.InjectionMolding.Command.UpdateInjectionModling;
using DataMgmtModule.Application.Feactures.InjectionMolding.Query.GetAllInjectionMolding;
using DataMgmtModule.Application.Feactures.InjectionMolding.Query.GetByIdInjectionMolding;
using DataMgmtModule.Application.Feactures.InjectionMolding.Query.InjectionMoldingById;
using DataMgmtModule.Application.Feactures.Materials.Query.GetMaterialById;
using DataMgmtModule.Application.Feactures.RecipeFeacture.Query.GetAllRecipes;
using DataMgmtModule.Application.Features.InjectionMolding.Command.DeleteInjectionModling;
using DataMgmtModule.InjectionMoldingInjectionMolding.InjectionMolding;
using DataMgmtModule.Persistence;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DataMgmtModule.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InjectionModling : ControllerBase
    {
        private readonly IMediator _mediator;
        readonly PersistenceDbContext _persistenceDbContext;

        public InjectionModling(IMediator mediator, PersistenceDbContext persistenceDbContext)
        {
            _mediator = mediator;
            _persistenceDbContext = persistenceDbContext;
        }
        //[HttpGet("search-by-date")]
        //public async Task<IActionResult> SearchByDate(int recipeId,DateOnly searchDate)
        //{
        //    // Convert DateOnly to DateTime range (whole day)
        //    DateTime startDate = searchDate.ToDateTime(TimeOnly.MinValue); // 00:00:00
        //    DateTime endDate = searchDate.ToDateTime(TimeOnly.MaxValue);  // 23:59:59.999

        //    var records = await _persistenceDbContext.InjectionMoldings
        //        .Where(e => e.CreatedDate >= startDate && e.CreatedDate <= endDate)
        //        .Where(d=>d.IsDelete==false)
        //        .Where(r=>r.RecipeId==recipeId)
        //        .ToListAsync();

        //    return Ok(records);
        //}

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<InjectionMoldingDto>>> GetAllInjectionModling()
        {
            var injectionmodling = await _mediator.Send(new GetAllInjectionMoldingQuery());
            return Ok(injectionmodling);
        }
        [HttpGet("GetLastParameterSet")]
        public async Task<IActionResult> GetLastParameterSet()
        {
            var lastParameterSet = await _persistenceDbContext.InjectionMoldings.OrderByDescending(x => x.Id).Select(p => p.ParameterSet).FirstOrDefaultAsync();
            return Ok(lastParameterSet);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteInjectionMolding(int moldingId,int deletedBy)
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            var result = await _mediator.Send(new DeleteInjectionModlingCommand(moldingId, deletedBy));

            if (result == 0)
                return NotFound($"Injection Molding record with ID {moldingId} not found.");

            return Ok($"Injection Molding record with ID {moldingId} deleted successfully.");
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateInjectionMolding(int id,[FromBody] UpdateInjectionMoldingDto injectionMoldingDto)
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var command =_mediator.Send( new UpdateInjectionModlingCommand(id,injectionMoldingDto,userId));

          

            return Ok(new { message = "Injection Molding updated successfully", affectedRows = command });
        }

        [HttpGet("GetByRecipeId/{recipeId}")]
        public async Task<IActionResult> GetInjectionMoldingById(int recipeId,DateOnly? searchDate)
        {
            var material = await _mediator.Send(new GetByIdInjectionMoldingQuery(recipeId,searchDate));
            return Ok(material);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> InjectionMoldingGetById(int Id)
        {
            var material = await _mediator.Send(new InjectionMoldingByIdQuery(Id));
            return Ok(material);
        }

        [HttpPost] 
        public async Task<IActionResult> Create([FromBody] AddInjectionMoldingDto dto)
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            var command = new CreateInjectionMoldingCommand(dto,userId);
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}

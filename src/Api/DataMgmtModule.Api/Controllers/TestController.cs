using DataMgmtModule.Application.Dtos.ContactDTO;
using DataMgmtModule.Application.Feactures.ProjectsFeactures.Query.GetAllProjects;
using DataMgmtModule.Application.Feactures.TestFeactures.Commands.AddTest;
using DataMgmtModule.Application.Feactures.TestFeactures.Commands.DeleteTest;
using DataMgmtModule.Application.Feactures.TestFeactures.Query.getRecipe;
using DataMgmtModule.Application.Feactures.TestFeactures.Query.GetTest;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DataMgmtModule.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TestController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAllTestData")]
        public async Task<IActionResult> GetAllTestData()
        {
            var result = await _mediator.Send(new GetTestQuery());
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteTest(int testId,int deletedBy)
        {
            return Ok(await _mediator.Send(new DeleteTestCommand(testId, deletedBy)));
        }

        [HttpPost("AddTest")]
        public async Task<IActionResult> AddTest([FromBody] AddTestCommand command)
        {
            if (command == null)
                return BadRequest("Invalid request data.");

            var newTestId = await _mediator.Send(command);
            return Ok(new { Id = newTestId });
        }
        [HttpGet("GetRecipeDataForTestList")]
        public async Task<IActionResult> GetRecipeData()
        {
            var result = await _mediator.Send(new GetRecipeQuery());
            return Ok(result);
        }


    }
}

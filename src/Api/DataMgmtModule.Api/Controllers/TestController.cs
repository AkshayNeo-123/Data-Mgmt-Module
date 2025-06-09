using DataMgmtModule.Application.Dtos.ContactDTO;
using DataMgmtModule.Application.Feactures.ProjectsFeactures.Query.GetAllProjects;
using DataMgmtModule.Application.Feactures.TestFeactures.Commands.AddTest;
using DataMgmtModule.Application.Feactures.TestFeactures.Commands.DeleteTest;
using DataMgmtModule.Application.Feactures.TestFeactures.Query.getRecipe;
using DataMgmtModule.Application.Feactures.TestFeactures.Query.GetTest;
using DataMgmtModule.Application.Feactures.TestFeactures.Query.GetTestById;
using DataMgmtModule.Application.Feactures.TestFeactures.Query.GetTestDataForExport;


//using DataMgmtModule.Application.Feactures.TestFeactures.Query.GetTestById;
using DataMgmtModule.Application.Features.TestFeatures.Commands.UpdateTest;
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

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateTest([FromBody] UpdateTestCommand command, int id)
        {
            // 🟢 Inject the ID from route into the command object
            command.TestId = id;

            var result = await _mediator.Send(command);

            if (result == 0)
                return NotFound("Test with the given ID was not found.");

            return Ok(new { message = "Test updated successfully." });
        }

        [HttpGet("GetTestById/{id}")]
        public async Task<IActionResult> GetTestById(int id)
        {
            var test = await _mediator.Send(new GetTestByIdQuery(id));

            if (test == null)
            {
                return NotFound($"Test with ID {id} not found");
            }

            return Ok(test);
        }

        [HttpGet("ExpoortTestData")]
        public async Task<IActionResult> GetTestDataForExport()
        {
            var result = await _mediator.Send(new GetTestDataForExportQuery());
            return Ok(result);

        }

    }
}

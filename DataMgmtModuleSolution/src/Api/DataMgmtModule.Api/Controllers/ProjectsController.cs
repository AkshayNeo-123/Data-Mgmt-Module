using DataMgmtModule.Application.Dtos.ProjectsDtos;
using DataMgmtModule.Application.Feactures.ProjectsFeactures.Commands.AddProjects;
using DataMgmtModule.Application.Feactures.ProjectsFeactures.Commands.DeleteProject;
using DataMgmtModule.Application.Feactures.ProjectsFeactures.Commands.UpdateProject;
using DataMgmtModule.Application.Feactures.ProjectsFeactures.Query.GetAllProjects;
using DataMgmtModule.Application.Feactures.ProjectsFeactures.Query.GetProjectById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DataMgmtModule.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        readonly IMediator _mediator;
        public ProjectsController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet("GetAllProjects")]
        public async Task<IActionResult> GetAllProjects()
        {
            var result = await _mediator.Send(new GetAllProjectsQuery());
            return Ok(result);
        }
        [HttpGet("GetProjectById")]
        public async Task<IActionResult> GetProjectById(int id)
        {
            var result = await _mediator.Send(new GetProjectByIdCommand(id));
            return Ok(result);
        }

        [HttpPost("AddProject")]
        public async Task<IActionResult> AddProject(AddProjectDto project)
        {
            var result = await _mediator.Send(new AddProjectsCommand(project));
            return Ok(new {Messge="Added Successfully!!"});
        }

        [HttpDelete("DeleteProject")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            var result = await _mediator.Send(new DeleteProjectCommand(id));
            if (result == 0)
            {
                return Ok(new { Messge = "It is already Deleted!!" });
            }
            return Ok(new { Messge = "Deleted Successfully!!" });
        }

        [HttpPut("UpdateProject")]
        public async Task<IActionResult> UpdateProject(int id,UpdateProjectDto updateProject)
        {
            var result = await _mediator.Send(new UpdateProjectCommand(id,updateProject));
            if (result >= 0)
            {
                return Ok(new { Messge = "Update Project Successfully!!" });
            }
            return Ok(new { Messge = "Project not Updated!!" });
        }



    }
}

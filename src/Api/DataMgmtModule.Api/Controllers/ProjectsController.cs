using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Application.Dtos.ProjectsDtos;
using DataMgmtModule.Application.Feactures.ProjectsFeactures.Commands.AddProjects;
using DataMgmtModule.Application.Feactures.ProjectsFeactures.Commands.DeleteProject;
using DataMgmtModule.Application.Feactures.ProjectsFeactures.Commands.UpdateProject;
using DataMgmtModule.Application.Feactures.ProjectsFeactures.Query.GetAllProjects;
using DataMgmtModule.Application.Feactures.ProjectsFeactures.Query.GetProjectById;
using DataMgmtModule.Domain.Entities;
using DataMgmtModule.Persistence;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;

namespace DataMgmtModule.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ProjectsController : ControllerBase
    {
        readonly IMediator _mediator;
        readonly PersistenceDbContext _persistenceDbContext;
        public ProjectsController(IMediator mediator, PersistenceDbContext persistenceDbContex)
        {
            _mediator = mediator;
            _persistenceDbContext = persistenceDbContex;
        }

        [HttpGet("GetLastProjectNumber")]
        public async Task<IActionResult> GetLastProjectNumber()
        {
            var lastProject = await _persistenceDbContext.Projects.OrderByDescending(x => x.ProjectId).Select(p => p.ProjectNumber).FirstOrDefaultAsync();
            return Ok(lastProject);
        }


     


        [HttpGet("Expoted file")]
        public IActionResult ExportData()
        {
            var projects = _persistenceDbContext.Projects.Where(x => x.IsDelete == false).ToList();
            var csv = ConvertToCsv(projects);
            var bytes = Encoding.UTF8.GetBytes(csv);
            return File(bytes, "application/csv", "projects.csv");
        }

        private string ConvertToCsv(List<Projects> projects)
        {
            var csvBuilder = new StringBuilder();
            csvBuilder.AppendLine("ProjectName,ProjectType,Area,Priority,Description,StartDate,EndDate");

            foreach (var project in projects)
            {
                csvBuilder.AppendLine($"{project.ProjectName},{project.ProjectTypes},{project.Areas},{project.Priorities},{project.Project_Description},{project.StartDate.ToString()},{project.EndDate.ToString()}");
            }

            return csvBuilder.ToString();
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
            int? userId = HttpContext.Session.GetInt32("UserId");
            var result = await _mediator.Send(new AddProjectsCommand(project,userId));
            return Ok(new {Messge="Added Successfully!!"});
        }

        [HttpDelete("DeleteProject")]
        public async Task<IActionResult> DeleteProject(int id,int? deletedBy)
        {
            var result = await _mediator.Send(new DeleteProjectCommand(id, deletedBy));
            if (result == 0)
            {
                return Ok(new { Messge = "It is already Deleted!!" });
            }
            return Ok(new { Messge = "Deleted Successfully!!" });
        }

        [HttpPut("UpdateProject")]
        public async Task<IActionResult> UpdateProject(int id,UpdateProjectDto updateProject)
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            var result = await _mediator.Send(new UpdateProjectCommand(id,updateProject,userId));
            if (result >= 0)
            {
                return Ok(new { Messge = "Update Project Successfully!!" });
            }
            return Ok(new { Messge = "Project not Updated!!" });
        }



    }
}

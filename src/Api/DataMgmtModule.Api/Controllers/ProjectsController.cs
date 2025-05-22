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


        //[HttpGet("Expoted file")]
        //public IActionResult ExportData()
        //{
        //    ExcelPackage.LicenseContext = LicenseContext.Commercial;
        //    var projects = _persistenceDbContext.Projects.Where(x => x.IsDelete == false).ToList();

        //    using var package = new OfficeOpenXml.ExcelPackage();
        //    var worksheet = package.Workbook.Worksheets.Add("Projects");

        //    // Add header
        //    worksheet.Cells[1, 1].Value = "ProjectName";
        //    worksheet.Cells[1, 2].Value = "ProjectType";
        //    worksheet.Cells[1, 3].Value = "Area";
        //    worksheet.Cells[1, 4].Value = "Priority";
        //    worksheet.Cells[1, 5].Value = "Description";
        //    worksheet.Cells[1, 6].Value = "StartDate";
        //    worksheet.Cells[1, 7].Value = "EndDate";

        //    // Add data
        //    for (int i = 0; i < projects.Count; i++)
        //    {
        //        var project = projects[i];
        //        worksheet.Cells[i + 2, 1].Value = project.ProjectName;
        //        worksheet.Cells[i + 2, 2].Value = project.ProjectTypes;
        //        worksheet.Cells[i + 2, 3].Value = project.Areas;
        //        worksheet.Cells[i + 2, 4].Value = project.Priorities;
        //        worksheet.Cells[i + 2, 5].Value = project.Project_Description;
        //        worksheet.Cells[i + 2, 6].Value = project.StartDate.HasValue
        //        ? project.StartDate.Value.ToString("yyyy-MM-dd")
        //        : "";

        //        worksheet.Cells[i + 2, 7].Value = project.EndDate.HasValue
        //            ? project.EndDate.Value.ToString("yyyy-MM-dd")
        //            : "";
        //        //worksheet.Cells[i + 2, 6].Value = project.StartDate.ToString("yyyy-MM-dd")??"";
        //        //worksheet.Cells[i + 2, 7].Value = project.EndDate.ToString("yyyy-MM-dd")??"";
        //    }

        //    var stream = new MemoryStream(package.GetAsByteArray());
        //    return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "projects.xlsx");
        //}


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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Application.Exceptions;
using DataMgmtModule.Application.Interface.Persistence;
using DataMgmtModule.Domain.Entities;
using DataMgmtModule.Domain.Enum.ProjectsEnums;
using Microsoft.EntityFrameworkCore;

namespace DataMgmtModule.Persistence.Repository
{
    public class ProjectsRepository : IProjects
    {
        readonly PersistenceDbContext _persistenceDbContext;
        public ProjectsRepository(PersistenceDbContext persistenceDbContext)
        {
            _persistenceDbContext = persistenceDbContext;
        }

        public async Task<int> AddProject(Projects project, int? userId)
        {
            project.Status = Status.Planed;
            project.IsDelete = false;
            project.CreatedDate = DateTime.Now;
            project.CreatedBy = 1;

            _persistenceDbContext.Add(project);
            return await _persistenceDbContext.SaveChangesAsync();
            
        }
        public async Task<IEnumerable<Projects>> GetAllProjects()
        {
            var projects = await _persistenceDbContext.Projects.Where(x=>x.IsDelete==false).ToListAsync();
            foreach(var project in projects)
            {
                if (project.Status == Status.OnGoing)
                {
                    if (project.EndDate < DateTime.Now)
                    {
                     project.Status = Status.Completed;
                     await _persistenceDbContext.SaveChangesAsync();
                    }

                    
                }
                if(project.Status == Status.Planed)
                {
                    if (DateTime.Now < project.CreatedDate)
                    {
                        project.Status = Status.OnGoing;
                        await _persistenceDbContext.SaveChangesAsync();
                    }
                }
            }
            return projects;

        }

        public async Task<int> DeleteProject(int id)
        {
            var project =await GetProjectById(id);
            if (project.IsDelete == false)
            {
                project.IsDelete = true;
                return await _persistenceDbContext.SaveChangesAsync();
            }
            return 0;
            

        }


        public async Task<Projects> GetProjectById(int id)
        {
            var project = await _persistenceDbContext.Projects.FirstOrDefaultAsync(x => x.ProjectId == id);
            if (project == null)
            {
                throw new NotFoundException("Project not found");
            }
            return project;

        }

        public async Task<int> UpdateProject(int id,Projects updatedProject, int? userId)
        {
            var project = await GetProjectById(id);
            project.ModifiedDate = DateTime.Now;
            project.ModifiedBy = userId;

            project.Priority = updatedProject.Priority;
            project.ProjectName = updatedProject.ProjectName;
            project.Project_Description = updatedProject.Project_Description;
            project.ProjectType = updatedProject.ProjectType;
            project.Area = updatedProject.Area;
            project.StartDate = updatedProject.StartDate;
            project.EndDate = updatedProject.EndDate;
            return await _persistenceDbContext.SaveChangesAsync();

        }
    }
}

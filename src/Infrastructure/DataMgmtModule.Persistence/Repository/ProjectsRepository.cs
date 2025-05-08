using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Application.Exceptions;
using DataMgmtModule.Application.Interface.Persistence;
using DataMgmtModule.Domain.Entities;
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
            
            project.IsDelete = false;
            project.CreatedDate = DateTime.Now;
            

            _persistenceDbContext.Add(project);
            return await _persistenceDbContext.SaveChangesAsync();
            
        }
        public async Task<IEnumerable<Projects>> GetAllProjects()
        {
            var projects = await _persistenceDbContext.Projects.Where(x=>x.IsDelete==false).Include(x=>x.ProjectTypes).Include(x => x.Areas).Include(x => x.Priorities).Include(x => x.Status).ToListAsync();
            //foreach(var project in projects)
            //{
            //    if (project.Status == Status.OnGoing)
            //    {
            //        if (project.EndDate < DateTime.Now)
            //        {
            //         project.Status = Status.Completed;
            //         await _persistenceDbContext.SaveChangesAsync();
            //        }

                    
            //    }
            //    if(project.Status == Status.Planed)
            //    {
            //        if (DateTime.Now < project.StartDate)
            //        {
            //            project.Status = Status.OnGoing;
            //            await _persistenceDbContext.SaveChangesAsync();
            //        }
            //    }
            //}
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
            project.ModifiedBy = updatedProject.ModifiedBy;
            project.StatusId = updatedProject.StatusId;

            project.PriorityId = updatedProject.PriorityId;
            project.ProjectName = updatedProject.ProjectName;
            project.Project_Description = updatedProject.Project_Description;
            project.ProjectTypeId = updatedProject.ProjectTypeId;
            project.AreaId = updatedProject.AreaId;
            //if (updatedProject.StartDate!=null)
            //{

            project.StartDate = updatedProject.StartDate;
            //}
            project.EndDate = updatedProject.EndDate;
            return await _persistenceDbContext.SaveChangesAsync();

        }
        

    }
}

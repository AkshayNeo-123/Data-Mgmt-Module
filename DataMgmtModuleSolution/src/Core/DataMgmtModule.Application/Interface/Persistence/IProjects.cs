using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Domain.Entities;

namespace DataMgmtModule.Application.Interface.Persistence
{
    public interface IProjects
    {
        Task<IEnumerable<Projects>> GetAllProjects();
        Task<int> AddProject(Projects project);
        Task<Projects> GetProjectById(int id);

        Task<int> DeleteProject(int id);
        Task<int> UpdateProject(int id, Projects project);
    }
}

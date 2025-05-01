using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Application.Interface.Persistence;
using DataMgmtModule.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataMgmtModule.Persistence.Repository
{
    public class ProjectTypeRepository : IProjectTypeRepository
    {
        readonly PersistenceDbContext _persistenceDbContext;
        public ProjectTypeRepository(PersistenceDbContext persistenceDbContext)
        {
            _persistenceDbContext = persistenceDbContext;
        }
        public async Task<IEnumerable<ProjectTypes>> GetAllProjectTypes()
        {
            return await _persistenceDbContext.ProjectTypes.ToListAsync();
        }
    }
}

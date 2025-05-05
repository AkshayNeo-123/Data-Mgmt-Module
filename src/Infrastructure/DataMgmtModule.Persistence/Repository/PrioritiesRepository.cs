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
    public class PrioritiesRepository : IPrioritiesRepository
    {

        readonly PersistenceDbContext _persistenceDbContext;
        public PrioritiesRepository(PersistenceDbContext persistenceDbContext)
        {
            _persistenceDbContext = persistenceDbContext;
        }
        public async Task<IEnumerable<Priorities>> GetAllPriorities()
        {
            return await _persistenceDbContext.Priorities.ToListAsync();
        }
    }
}

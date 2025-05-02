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
    public class StatusRepository : IStatusRepository
    {
        readonly PersistenceDbContext _persistenceDbContext;
        public StatusRepository(PersistenceDbContext persistenceDbContext)
        {
            _persistenceDbContext = persistenceDbContext;
        }
        public async Task<IEnumerable<Status>> GetAllStatus()
        {
            return await _persistenceDbContext.Status.ToListAsync();
        }
    }
}

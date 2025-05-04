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
    public class AreasRepository : IAreasRepository
    {
        readonly PersistenceDbContext _dbContext;
        public AreasRepository(PersistenceDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Areas>> GetAllAreas()
        {
            return await _dbContext.Areas.ToArrayAsync();
        }
    }
}

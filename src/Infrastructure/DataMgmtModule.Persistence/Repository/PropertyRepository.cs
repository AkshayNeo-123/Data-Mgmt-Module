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
    public class PropertyRepository: IPropertyRepository
    {
        readonly PersistenceDbContext _dbContext;
        public PropertyRepository(PersistenceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Properties> GetByTestId(int id)
        {
            var data = await _dbContext.Properties.Where(t => t.TestId == id).FirstOrDefaultAsync();

            return data;
        }
    }
}

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
    public class TemperaturePropertyRepository: ITemperaturePropertyRepository
    {
        readonly PersistenceDbContext _dbContext;
        public TemperaturePropertyRepository(PersistenceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TemperatureProperty> GetByTestId(int id)
        {
            var data = await _dbContext.TemperatureProperties.Where(t => t.TestId == id).FirstOrDefaultAsync();

            return data;
        }
    }
}

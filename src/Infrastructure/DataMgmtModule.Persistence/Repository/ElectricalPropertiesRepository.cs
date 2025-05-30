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
    public class ElectricalPropertiesRepository: IElectricalPropertiesRepository
    {
        readonly PersistenceDbContext _dbContext;
        public ElectricalPropertiesRepository(PersistenceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ElectricalProperties> GetByTestId(int id)
        {
            var data = await _dbContext.ElectricalProperties.Where(t => t.TestId == id && t.IsDelete == false).FirstOrDefaultAsync();

            return data;
        }
    }
}

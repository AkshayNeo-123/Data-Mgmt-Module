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
    public class MechanicalPropertyRepository: IMechanicalPropertyRepository
    {
        readonly PersistenceDbContext _dbContext;
        public MechanicalPropertyRepository(PersistenceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<MechanicalProperty> GetByTestId(int id)
        {
            var data = await _dbContext.MechanicalProperties.Where(t => t.TestId == id && t.IsDelete == false).FirstOrDefaultAsync();

            return data;
        }

    }
}

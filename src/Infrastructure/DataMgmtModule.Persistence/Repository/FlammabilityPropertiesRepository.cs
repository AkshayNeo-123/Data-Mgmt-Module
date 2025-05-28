using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Application.Interface.Persistence;

namespace DataMgmtModule.Persistence.Repository
{
    public class FlammabilityPropertiesRepository: IFlammabilityPropertiesRepository
    {
        readonly PersistenceDbContext _dbContext;
        public FlammabilityPropertiesRepository(PersistenceDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}

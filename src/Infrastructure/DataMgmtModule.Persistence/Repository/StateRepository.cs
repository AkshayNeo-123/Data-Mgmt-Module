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
    public class StateRepository : IStateRepository
    {
        public readonly PersistenceDbContext _persistenceDbContext;
        public StateRepository(PersistenceDbContext persistenceDbContext)
        {
            _persistenceDbContext = persistenceDbContext;
        }

        //public async Task<IEnumerable<Cities>> GetAllCities()
        //{
        //    return await _persistenceDbContext.Cities.ToListAsync();
        //}

        public async Task<IEnumerable<States>> GetAllStates()
        {
            var getAllStates = await _persistenceDbContext.States.ToListAsync();
            return getAllStates;
        }
    }

}

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

        public async Task<Cities> AddCityAsync(Cities city)
        {
            var addCity=await _persistenceDbContext.AddAsync
                (city);
            await _persistenceDbContext.SaveChangesAsync();
            return addCity.Entity
                ;
        }

        public async Task<IEnumerable<States>> GetAllStates()
        {
            var getAllStates = await _persistenceDbContext.States.ToListAsync();
            return getAllStates;
        }

        public Task<IEnumerable<Cities>> GetCitiesByStateAsync(int stateId)
        {
            throw new NotImplementedException();
        }

        //public async Task<IEnumerable<Cities>> GetCitiesByStateAsync(int stateId)
        //{
        //    var getCityById = await _persistenceDbContext.Cities.Where(x => x.StateId == stateId).ToListAsync();
        //    return getCityById;
        //}
    }

}

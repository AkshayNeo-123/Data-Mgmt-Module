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

        public async Task<Cities> AddCityAsync(string cityName,int stateId)
        {
            var existingCity = await _persistenceDbContext.Cities.Where(x => x.StateId == stateId &&  x.CityName==cityName).FirstOrDefaultAsync();

            if (existingCity != null)
            {
                return existingCity;
            }

            var newCity = new Cities
            {
                
                    StateId = stateId,
                CityName = cityName
            };
            var addCity=await _persistenceDbContext.AddAsync
                (newCity);
            await _persistenceDbContext.SaveChangesAsync();
            return newCity;
                ;
        }

        public async Task<States> AddStatesAsync(States states)
        {
            var addStates=await _persistenceDbContext.AddAsync(states);
            await _persistenceDbContext.SaveChangesAsync();
            return states;
        }

        public async Task<IEnumerable<States>> GetAllStatesAsync()
        {
            var getAllStates = await _persistenceDbContext.States.ToListAsync();
            return getAllStates;
        }

        public async Task<IEnumerable<Cities>> GetCitiesByStateAsync(int stateId)
        {
            var getCityById = await _persistenceDbContext.Cities.Where(x => x.StateId == stateId).ToListAsync();
            return getCityById;
        }

        
    }

}

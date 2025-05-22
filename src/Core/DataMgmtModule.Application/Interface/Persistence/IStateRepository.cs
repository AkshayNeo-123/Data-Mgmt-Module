using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Domain.Entities;

namespace DataMgmtModule.Application.Interface.Persistence
{
    public interface IStateRepository
    {
        Task<IEnumerable<States>> GetAllStatesAsync();
        Task<IEnumerable<Cities>> GetCitiesByStateAsync(int stateId);
        Task<Cities>AddCityAsync(string  cityName,int stateId);
        Task<States> AddStatesAsync(States states);
    }
}

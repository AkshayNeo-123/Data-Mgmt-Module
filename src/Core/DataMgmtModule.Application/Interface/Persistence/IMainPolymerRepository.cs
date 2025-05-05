using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Application.Dtos.MainPolymerDtos;
using DataMgmtModule.Domain.Entities;

namespace DataMgmtModule.Application.Interface.Persistence
{
    public interface IMainPolymerRepository
    {
        Task<List<MainPolymer>> GetAllAsync();
        Task<MainPolymer?> GetByIdAsync(int id);
        Task<MainPolymer> AddAsync(CreateMainPolymerDto dto,int? userId);
        Task<bool> UpdateAsync(int id, UpdateMainPolymerDto dto, int? userId);
        Task<bool> DeleteAsync(int id);
    }
}

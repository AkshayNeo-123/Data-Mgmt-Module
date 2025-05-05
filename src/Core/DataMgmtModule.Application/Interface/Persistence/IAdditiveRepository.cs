using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Application.Dtos.AdditiveDtos;
using DataMgmtModule.Domain.Entities;

namespace DataMgmtModule.Application.Interface.Persistence
{
    public interface IAdditiveRepository
    {
        Task<List<Additive>> GetAllAsync();
        Task<Additive?> GetByIdAsync(int id);
        Task<Additive> AddAsync(CreateAdditiveDto dto,int? userId);
        Task<bool> UpdateAsync(int id, UpdateAdditiveDto dto, int? userId);
        Task<bool> DeleteAsync(int id);
    }
}

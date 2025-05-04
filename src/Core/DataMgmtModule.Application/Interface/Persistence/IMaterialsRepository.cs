
using DataMgmtModule.Domain.Entities;

namespace DataMgmtModule.Application.Interface.Persistence
{
    public interface IMaterialsRepository
    {
        Task<IEnumerable<Materials>> GetAllMaterials();
        Task<Materials?> GetByIdMaterials(int id);
        Task<Materials> AddMaterials(Materials material,int? userId);
        Task UpdateMaterials(Materials material,int? userId);
        Task <int> DeleteMaterials(int id);
      
    }
}

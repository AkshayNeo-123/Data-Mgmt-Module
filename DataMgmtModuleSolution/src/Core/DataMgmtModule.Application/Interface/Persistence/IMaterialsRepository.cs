
using DataMgmtModule.Domain.Entities;

namespace DataMgmtModule.Application.Interface.Persistence
{
    public interface IMaterialsRepository
    {
        Task<IEnumerable<Materials>> GetAllMaterials();
        Task<Materials?> GetByIdMaterials(int id);
        Task<Materials> AddMaterials(Materials material);
        Task UpdateMaterials(Materials material);
        Task DeleteMaterials(int id);
    }
}

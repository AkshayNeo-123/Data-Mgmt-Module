using DataMgmtModule.Domain.Entities;

namespace DataMgmtModule.Application.Interfaces.Persistence
{
    public interface IRecipeComponentTypeRepository
    {
        Task<List<RecipeComponentType>> GetAllAsync();
    }
}

using DataMgmtModule.Application.Interfaces.Persistence;
using DataMgmtModule.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataMgmtModule.Persistence.Repository
{
    public class RecipeComponentTypeRepository : IRecipeComponentTypeRepository
    {
        private readonly PersistenceDbContext _context;

        public RecipeComponentTypeRepository(PersistenceDbContext context)
        {
            _context = context;
        }

        public async Task<List<RecipeComponentType>> GetAllAsync()
        {
            return await _context.RecipeComponentType.ToListAsync();
        }
    }
}

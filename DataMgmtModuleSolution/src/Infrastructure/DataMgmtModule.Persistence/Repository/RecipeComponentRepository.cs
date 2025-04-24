using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Application.Dtos;
using DataMgmtModule.Application.Interface.Persistence;
using DataMgmtModule.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataMgmtModule.Persistence.Repository
{
    public class RecipeComponentRepository : IRecipeComponent
    {
        readonly PersistenceDbContext _persistenceDbContext;
        public RecipeComponentRepository(PersistenceDbContext persistenceDbContext)
        {
            _persistenceDbContext = persistenceDbContext;
        }
        public async Task<int> AddRecipeComponent(int id, RecipeComponent component)
        {
            component.RecipeId = id;
            component.CreatedBy = 1;
            component.CreatedDate = DateTime.Now;
             _persistenceDbContext.RecipeComponents.Add(component);
            return await _persistenceDbContext.SaveChangesAsync();
        }



        public async Task<List<RecipeComponent>> GetAllAsync() => await _persistenceDbContext.RecipeComponents.ToListAsync();

        public async Task<RecipeComponent?> GetByIdAsync(int id) =>
            await _persistenceDbContext.RecipeComponents.FindAsync(id);

        public async Task<RecipeComponent> AddAsync(RecipeComponent component)
        {
            _persistenceDbContext.RecipeComponents.Add(component);
            await _persistenceDbContext.SaveChangesAsync();
            return component;
        }

        public async Task<bool> UpdateAsync(int id, UpdateRecipeComponentDto dto)
        {
            try
            {
                var existing = await _persistenceDbContext.RecipeComponents.FirstOrDefaultAsync(x => x.RecipeComponentId == id);
                if (existing == null) return false;

                _persistenceDbContext.Entry(existing).CurrentValues.SetValues(dto);
                await _persistenceDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Update failed: {ex.Message}", ex);
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var component = await _persistenceDbContext.RecipeComponents.FindAsync(id);
            if (component == null) return false;

            _persistenceDbContext.RecipeComponents.Remove(component);
            await _persistenceDbContext.SaveChangesAsync();
            return true;
        }
    }
}

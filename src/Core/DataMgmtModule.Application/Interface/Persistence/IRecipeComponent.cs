using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Application.Dtos;
using DataMgmtModule.Domain.Entities;

namespace DataMgmtModule.Application.Interface.Persistence
{
    public interface IRecipeComponent
    {
        Task<int> AddRecipeComponent(int id,RecipeComponent component,int? userId);

        Task<List<RecipeComponent>> GetAllAsync();
        Task<RecipeComponent?> GetByIdAsync(int id);
        Task<RecipeComponent> AddAsync(RecipeComponent component);
        Task<bool> UpdateAsync(int id, UpdateRecipeComponentDto dto);
        Task<bool> DeleteAsync(int id);
    }
}

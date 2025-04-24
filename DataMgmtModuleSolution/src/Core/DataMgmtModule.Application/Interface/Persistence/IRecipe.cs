
using DataMgmtModule.Domain.Entities;

namespace DataMgmtModule.Application.Interface.Persistence
{
    public interface IRecipe
    {
        Task<int> AddRecipe(Recipe recipe);
        Task<int> DeleteRecipe(int id,int? userId);
        Task<int> UpdateRecipe(int id,Recipe recipe); 
        Task<int> UpdateRecipeComponent(int id, RecipeComponent[] recipeComponent);
        Task<Recipe> RecipeFindById(int id);
        Task<IEnumerable<Recipe>> GetAllRecipes();
        
    }
}


using DataMgmtModule.Application.Dtos.RecipeDtos;
using DataMgmtModule.Domain.Entities;

namespace DataMgmtModule.Application.Interface.Persistence
{
    public interface IRecipe
    {
        Task<int> AddRecipe(Recipe recipe,int? userId);
        Task<int> DeleteRecipe(int id);
        Task<int> DeleteRecipeSoft(int id);
        Task<int> UpdateRecipe(int id,Recipe recipe, int? userId); 
        Task<int> UpdateRecipeComponent(int id, RecipeComponent[] recipeComponent,int? userId);
        Task<Recipe> RecipeFindById(int id);
        Task<IEnumerable<GetAllRecipeDtos>> GetAllRecipes();
        Task<IEnumerable<RecipeProjectDTO>> GetRecipeAndPrjectAsync(string projectNumber);
        Task<RecipeProjectDTO> GetRecipeProjectById(int id);
        
    }
}

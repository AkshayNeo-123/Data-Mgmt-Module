using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Application.Exceptions;
using DataMgmtModule.Application.Interface.Persistence;
using DataMgmtModule.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataMgmtModule.Persistence.Repository
{
    public class RecipeRepository : IRecipe
    {
        readonly PersistenceDbContext _persistenceDbContext;
        public RecipeRepository(PersistenceDbContext persistenceDbContext)
        {
            _persistenceDbContext = persistenceDbContext;
        }

        public async Task<IEnumerable<Recipe>> GetAllRecipes()
        {
            return await _persistenceDbContext.Recipes.ToListAsync();
        }
        public async Task<int> AddRecipe(Recipe recipe)
        {
            recipe.CreatedDate = DateTime.Now;
            await _persistenceDbContext.Recipes.AddAsync(recipe);
            await _persistenceDbContext.SaveChangesAsync();
            var result = _persistenceDbContext.Recipes.OrderByDescending(x => x.ReceipeId).FirstOrDefault();
            return result.ReceipeId;
        }

        public async Task<int> DeleteRecipe(int id)
        {
            var components = await _persistenceDbContext.RecipeComponents
                .Where(x => x.RecipeId == id)
                .ToListAsync();

            var recipe = await _persistenceDbContext.Recipes
                .FirstOrDefaultAsync(r => r.ReceipeId == id);

            if (recipe == null)
            {
                return 0;
            }

            // 👇 Create log entry
            var log = new RecipesLog
            {
                RecipeId = recipe.ReceipeId,
                ProductName = recipe.ProductName,
                Comments = recipe.Comments,
                ProjectId = recipe.ProjectId,
                CreatedDate = recipe.CreatedDate,
                AdditiveId = recipe.AdditiveId,
                MainPolymerId = recipe.MainPolymerId,
                DeletedBy = "Admin",
                DeletedDate = DateTime.UtcNow
            };

            await _persistenceDbContext.RecipesLogs.AddAsync(log);

            _persistenceDbContext.RecipeComponents.RemoveRange(components);
            //_persistenceDbContext.Recipes.Remove(recipe);

            return await _persistenceDbContext.SaveChangesAsync();

            

        }
        public async Task<Recipe> RecipeFindById(int id)
        {
            var recipe = await _persistenceDbContext.Recipes.Where(x => x.ReceipeId == id).FirstOrDefaultAsync();
            if (recipe == null)
            {
                throw new NotFoundException($" Recipe ID={id} is not Found!!");
            }
            return recipe;
        }


        public async Task<int> UpdateRecipe(int id,Recipe recipe)
        {
            var result =await RecipeFindById(id);
            result.ProductName = recipe.ProductName;
            result.Comments = recipe.Comments;
            return await _persistenceDbContext.SaveChangesAsync();


        }

        public async Task<int> UpdateRecipeComponent(int id, RecipeComponent[] recipeComponent)
        {

            var oldcomponent = await _persistenceDbContext.RecipeComponents.Where(x => x.RecipeId == id).ToListAsync();
            if (oldcomponent == null)
            {
                throw new NotFoundException($"Recipe Component not found with recipeId {id}");
            }
             _persistenceDbContext.RecipeComponents.RemoveRange(oldcomponent);
            await _persistenceDbContext.SaveChangesAsync();
            foreach(var item in recipeComponent)
            {
                item.RecipeId = id;
                await _persistenceDbContext.RecipeComponents.AddAsync(item);
                await _persistenceDbContext.SaveChangesAsync();

            }
            return 1;

        }
    }
}

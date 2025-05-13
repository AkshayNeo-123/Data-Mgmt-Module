using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Application.Dtos.RecipeDtos;
using DataMgmtModule.Application.Exceptions;
using DataMgmtModule.Application.Interface.Persistence;
using DataMgmtModule.Domain.Entities;
using Microsoft.AspNetCore.Http;
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

        public async Task<IEnumerable<GetAllRecipeDtos>> GetAllRecipes()
        {

            return await _persistenceDbContext.Recipes
        .Include(r => r.Project)
        .Include(r => r.Additive)
        .Include(r => r.MainPolymer)
        .Select(r => new GetAllRecipeDtos
        {
            ReceipeId = r.ReceipeId,
            MainPolymerId = r.MainPolymerId,
            ProjectId = r.ProjectId,
            AdditiveId = r.AdditiveId,
            ProductName = r.ProductName,
            Comments = r.Comments,
            ProjectNumber = r.Project != null ? r.Project.ProjectNumber : string.Empty,
            AdditiveName = r.Additive.AdditiveName,
            PolymerName = r.MainPolymer.PolymerName != null ? r.MainPolymer.PolymerName : string.Empty
        })
        .ToListAsync();
        }
       
        public async Task<int> AddRecipe(Recipe recipe, int? userId)
        {
            recipe.CreatedDate = DateTime.Now;
            recipe.CreatedBy = userId;

            await _persistenceDbContext.Recipes.AddAsync(recipe);
            await _persistenceDbContext.SaveChangesAsync();
            var result = _persistenceDbContext.Recipes.OrderByDescending(x => x.ReceipeId).FirstOrDefault();
            return result.ReceipeId;
        }

        public async Task<int> DeleteRecipe(int id,int? userId)
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
           
            var log = new RecipesLog
            {
                RecipeId = recipe.ReceipeId,
                ProductName = recipe.ProductName,
                Comments = recipe.Comments,
                ProjectId = recipe.ProjectId,
                CreatedDate = recipe.CreatedDate,
                AdditiveId = recipe.AdditiveId,
                MainPolymerId = recipe.MainPolymerId,
                DeletedBy = userId,
                DeletedDate = DateTime.UtcNow
            };

            await _persistenceDbContext.RecipesLogs.AddAsync(log);

            _persistenceDbContext.RecipeComponents.RemoveRange(components);
           

            return await _persistenceDbContext.SaveChangesAsync();

            

        }


        public async Task<Recipe> RecipeFindById(int id)
        {
            var recipe = await _persistenceDbContext.Recipes.Include(z=>z.MainPolymer).Include(z=>z.Project).Include( z=> z.Additive).Where(x => x.ReceipeId == id).FirstOrDefaultAsync();
            if (recipe == null)
            {
                throw new NotFoundException($" Recipe ID={id} is not Found!!");
            }
            return recipe;
        }


        public async Task<int> UpdateRecipe(int id,Recipe recipe, int? userId)
        {
            var result =await RecipeFindById(id);
            result.ProductName = recipe.ProductName;
            result.Comments = recipe.Comments;
            result.ModifiedBy = userId;
            result.ModifiedDate = DateTime.Now;
            return await _persistenceDbContext.SaveChangesAsync();


        }

        public async Task<int> UpdateRecipeComponent(int id, RecipeComponent[] recipeComponent, int? userId)
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
                item.ModifiedDate = DateTime.Now;
                item.ModifiedBy = userId;
                item.CreatedBy=userId;
                item.CreatedDate = DateTime.Now;
                await _persistenceDbContext.RecipeComponents.AddAsync(item);
                await _persistenceDbContext.SaveChangesAsync();

            }
            return 1;

        }
    }
}

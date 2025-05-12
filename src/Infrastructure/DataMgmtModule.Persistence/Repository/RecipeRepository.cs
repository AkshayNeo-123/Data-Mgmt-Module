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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
            //return await _persistenceDbContext.Recipes.Include(x=>x.Additive).Include(x=>x.MainPolymer).ToListAsync();
            return await _persistenceDbContext.Recipes.Select(r => new GetAllRecipeDtos
            {

                ProductName = r.ProductName,
                Comments = r.Comments,

                ProjectName = r.Project.ProjectName,

                CreatedBy = r.CreatedBy,
                ModifiedBy = r.ModifiedBy,
                CreatedDate = (DateTime)r.CreatedDate,
                ModifiedDate = r.ModifiedDate,


                AdditiveName = r.Additive.AdditiveName,

                PolymerName = r.MainPolymer.PolymerName,

            }).ToListAsync(); ;
        }
        //public string Comments { get; set; }
        //public int ProjectId { get; set; }
        //public DateTime CreatedDate { get; set; }
        //public int? CreatedBy { get; set; }
        //public int? ModifiedBy { get; set; }
        //public DateTime? ModifiedDate { get; set; }
        //public int AdditiveId { get; set; }
        //public int MainPolymerId { get; set; }
        public async Task<int> AddRecipe(Recipe recipe, int? userId)
        {
            recipe.CreatedDate = DateTime.Now;
            recipe.CreatedBy = userId;

            await _persistenceDbContext.Recipes.AddAsync(recipe);
            await _persistenceDbContext.SaveChangesAsync();
            var result = _persistenceDbContext.Recipes.OrderByDescending(x => x.ReceipeId).FirstOrDefault();
            return result.ReceipeId;
        }

        public async Task<int> DeleteRecipe(int id, int? userId)
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
            //var userId = HttpContext.Session.GetInt32("UserId");

            //  Create log entry
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


        public async Task<int> UpdateRecipe(int id, Recipe recipe, int? userId)
        {
            var result = await RecipeFindById(id);
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
            foreach (var item in recipeComponent)
            {
                item.RecipeId = id;
                item.ModifiedDate = DateTime.Now;
                item.ModifiedBy = userId;
                item.CreatedBy = userId;
                item.CreatedDate = DateTime.Now;
                await _persistenceDbContext.RecipeComponents.AddAsync(item);
                await _persistenceDbContext.SaveChangesAsync();

            }
            return 1;

        }

        public async Task<IEnumerable<RecipeProjectDTO>> GetRecipeAndPrjectAsync(string search)
        {
            var query = _persistenceDbContext.Recipes
        .Include(x => x.Project)
        .Where(x => x.Project.IsDelete == false);

            if (!string.IsNullOrWhiteSpace(search))
            {
                string loweredSearch = search.ToLower();
                query = query.Where(x =>
                    x.Project.ProjectNumber.ToString().Contains(loweredSearch) ||
                    x.Project.Project_Description.ToLower().Contains(loweredSearch) ||
                    x.ReceipeId.ToString().Contains(loweredSearch)
                );
            }

            return await query
                .Select(x => new RecipeProjectDTO
                {
                    RecipeId = x.ReceipeId,
                    ProjectNumber = x.Project.ProjectNumber,
                    Description = x.Project.Project_Description
                }).ToListAsync();
        }

        public async Task<RecipeProjectDTO> GetRecipeProjectById(int id)
        {
            var getById = await _persistenceDbContext.Recipes.Include(x => x.Project)
                .Where(x => x.ReceipeId == id)
                .Select(x => new RecipeProjectDTO
                {

                    RecipeId = x.ReceipeId,
                    ProjectNumber = x.Project.ProjectNumber,
                    Description = x.Project.Project_Description
                }).FirstOrDefaultAsync();
            if (getById == null)
            {
                throw new NotFoundException($" Recipe ID={id} is not Found!!");
            }
            return getById;
        }
    }

    
}
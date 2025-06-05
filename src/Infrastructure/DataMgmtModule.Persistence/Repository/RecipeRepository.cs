using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataMgmtModule.Application.Dtos.RecipeDtos;
using DataMgmtModule.Application.Dtos.TestDtos;
using DataMgmtModule.Application.Exceptions;
using DataMgmtModule.Application.Interface.Persistence;
using DataMgmtModule.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace DataMgmtModule.Persistence.Repository
{
    public class RecipeRepository : IRecipe
    {
        readonly PersistenceDbContext _persistenceDbContext;
        readonly IMapper _mapper;
        public RecipeRepository(PersistenceDbContext persistenceDbContext,IMapper mapper)
        {
            _persistenceDbContext = persistenceDbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetAllRecipeDtos>> GetAllRecipes()
        {

            return await _persistenceDbContext.Recipes.Where(x=>x.IsDelete==false)
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
            //Comments = r.Comments,
            ProjectNumber = r.Project != null ? r.Project.ProjectNumber : string.Empty,
            AdditiveName = r.Additive.AdditiveName,
            PolymerName = r.MainPolymer.PolymerName != null ? r.MainPolymer.PolymerName : string.Empty
        }).
             ToListAsync();
        }
       
        public async Task<int> AddRecipe(Recipe recipe, int? userId)
        {
            recipe.CreatedDate = DateTime.Now;
            //recipe.CreatedBy = userId;
            recipe.IsDelete = false;
            await _persistenceDbContext.Recipes.AddAsync(recipe);
            await _persistenceDbContext.SaveChangesAsync();
            var result = _persistenceDbContext.Recipes.OrderByDescending(x => x.ReceipeId).FirstOrDefault();
            return result.ReceipeId;
        }

        public async Task<int> DeleteRecipe(int id, int deletedBy)
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
                //DeletedBy = userId,
                DeletedDate = DateTime.UtcNow
            };

            await _persistenceDbContext.RecipesLogs.AddAsync(log);

            _persistenceDbContext.RecipeComponents.RemoveRange(components);

            if (recipe.IsDelete == false)
            {
                recipe.IsDelete = true;

               await _persistenceDbContext.SaveChangesAsync();

            }
            return 1;

        }


        public async Task<int> RecipeSoftDelete(int id,int deletedBy)
        {
            
            var recipes = await _persistenceDbContext.Recipes.FindAsync(id);
            if (recipes.IsDelete == false)
            {
                recipes.IsDelete = true;
                recipes.DeletedBy = deletedBy;
                recipes.DeletedDate = DateTime.Now;
                await _persistenceDbContext.SaveChangesAsync();
            }
            else
            {
                throw new NotFoundException("This Data not found");
            }
            return 1;
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
            result.AdditiveId = recipe.AdditiveId;
            result.MainPolymerId = recipe.MainPolymerId;
            result.ProjectId = recipe.ProjectId;
            result.ModifiedBy = recipe.ModifiedBy;
            result.ModifiedDate = DateTime.Now;
            return await _persistenceDbContext.SaveChangesAsync();


        }

        public async Task<IEnumerable<RecipeComponent>> FindRecipeComponents(int recipeId)
        {
            var componets = await _persistenceDbContext.RecipeComponents.Where(c => c.RecipeId == recipeId).ToListAsync();
            return componets;
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
                //item.ModifiedDate = DateTime.Now;
                //item.ModifiedBy = userId;
                //item.CreatedBy = userId;
                item.CreatedDate = DateTime.Now;
                await _persistenceDbContext.RecipeComponents.AddAsync(item);
                await _persistenceDbContext.SaveChangesAsync();

            }
            return 1;

        }

        public async Task<IEnumerable<RecipeProjectDTO>> GetRecipeAndProjectAsync(string search)
        {
            var query = _persistenceDbContext.Recipes
                .Include(t => t.Project)
                .Include(z => z.Test).ThenInclude(z => z.MechanicalProperty).Where(t => t.IsDelete == false ).ToList();


            //var query = await _persistenceDbContext.Recipes.Include(t => t.Project).Include(z => z.Test).ThenInclude(z => z.MechanicalProperty).Where(t => t.IsDelete == false);


            if (!string.IsNullOrWhiteSpace(search))
            {
                string loweredSearch = search.ToLower();
                query = query.Where(t =>
                    t.Project.ProjectNumber.ToLower().Contains(loweredSearch) ||
                    t.Project.Project_Description.ToLower().Contains(loweredSearch) ||
                    t.ProductName.ToLower().Contains(loweredSearch)
                ).ToList();
            }

            return  query
                .Select(t => new RecipeProjectDTO
                {
                    RecipeId = t.ReceipeId,
                    ProductName = t.ProductName,
                    ProjectNumber = t.Project?.ProjectNumber,
                    Description = t.Project?.Project_Description,
                    TensileModulus_DAM = t.Test?.MechanicalProperty?.TensileModulus_DAM,
                    CharpyImpact_DAM = t.Test?.MechanicalProperty?.CharpyImpact_DAM,
                    FlexuralStrength_DAM = t.Test?.MechanicalProperty?.FlexuralStrength_DAM
                    //Elongation = t.MechanicalProperties.Elongation
                }).DistinctBy(z => z.RecipeId).ToList();
                

            
        }

        public async Task<RecipeProjectDTO> GetRecipeAndProjectById(int id)
        {
             var getById=await _persistenceDbContext.Recipes.Include(t=>t.Project).Where(t=>t.ReceipeId==id)
            
                .Select(x => new RecipeProjectDTO
                {

                    RecipeId = x.ReceipeId,
                    ProductName=x.ProductName,
                    ProjectNumber = x.Project.ProjectNumber,
                    Description = x.Project.Project_Description,

                    //TensileModulus_DAM = x.MechanicalProperty.TensileModulus_DAM,
                    //CharpyImpact_DAM = x.MechanicalProperty.CharpyImpact_DAM,
                    //FlexuralStrength_DAM = x.MechanicalProperty.FlexuralStrength_DAM

                }).FirstOrDefaultAsync();
            if (getById == null)
            {
                throw new NotFoundException($" Recipe ID={id} is not Found!!");
            }
            return getById;

        }

        public async Task<CommonTestDto>GetTestPropertiesByRecipe(int id)
        {


            var getTestByRecipe = await _persistenceDbContext.Test
                .Where(x => x.RecipeNumber == id && x.IsPublish == true && x.IsDelete==false).FirstOrDefaultAsync();


            if (getTestByRecipe == null)
            {
                throw new NotFoundException($"Data with Id {id} not found");
            }

            var testDto = _mapper.Map<CommonTestDto>(getTestByRecipe);

            var mech = await _persistenceDbContext.MechanicalProperties.FirstOrDefaultAsync(x => x.TestId == getTestByRecipe.Id);
            if (mech != null)
            {
                testDto.MechanicalPropertyDto = _mapper.Map<MechanicalPropertyDto>(mech);
            }
            var electticalPro = await _persistenceDbContext.ElectricalProperties.FirstOrDefaultAsync(x => x.TestId == getTestByRecipe.Id);

            if (electticalPro != null)
            {
                testDto.ElectricalPropertyDto = _mapper.Map<ElectricalPropertyDto>(electticalPro);
            }
            var tempProperty = await _persistenceDbContext.TemperatureProperties.FirstOrDefaultAsync(x => x.TestId == getTestByRecipe.Id);
            if (tempProperty != null)
            {
                testDto.TemperaturePropertyDto = _mapper.Map<TemperaturePropertyDto>(tempProperty);
            }
            var generalProperty = await _persistenceDbContext.GeneralProperties.FirstOrDefaultAsync(x => x.TestId == getTestByRecipe.Id);
            if (generalProperty != null)
            {
                testDto.GeneralPropertyDto = _mapper.Map<GeneralPropertyDto>(generalProperty);
            }

            var properties = await _persistenceDbContext.Properties.FirstOrDefaultAsync(x => x.TestId == getTestByRecipe.Id);
            if (properties != null)
            {
                testDto.PropertiesDto = _mapper.Map<PropertiesDto>(properties);
            }
            var flam = await _persistenceDbContext.FlammabilityProperties
                    .FirstOrDefaultAsync(x => x.TestId == getTestByRecipe.Id);
            if (flam != null)
                testDto.FlammabilityPropertyDto = _mapper.Map<FlammabilityPropertyDto>(flam);


            return testDto;

        }

       
    }



    
}
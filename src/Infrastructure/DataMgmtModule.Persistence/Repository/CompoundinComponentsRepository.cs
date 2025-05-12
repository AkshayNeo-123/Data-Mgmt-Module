using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Application.Exceptions;
using DataMgmtModule.Application.Interface.Persistence;
using DataMgmtModule.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace DataMgmtModule.Persistence.Repository
{
    public class CompoundingComponentsRepository : ICompoundingComponentsRepository
    {
        private readonly PersistenceDbContext _persistenceDbContext;
        public CompoundingComponentsRepository(PersistenceDbContext persistenceDbContext)
        {
            _persistenceDbContext = persistenceDbContext;
        }
        public async Task<int> AddCompoundingComponents(int compoundingId, CompoundingComponent compoundingComponents, int? userId)
        {
            var compoundingData = await _persistenceDbContext.CompoundingData.Where(x=>x.CompoundingId== compoundingId).FirstOrDefaultAsync();  //select * from Compoundingdata where compoundingid= 

            if (compoundingData == null)
            {
                throw new Exception("CompoundingData not found!");
            }

            var componentData = await _persistenceDbContext.Components.FindAsync(compoundingComponents.ComponentId);
            if (componentData == null)
            {
                throw new Exception("Component not found!");
            }
           

            compoundingComponents.CompoundingId = compoundingId;
            //compoundingComponents.ComponentId = componentData.Id;
            //var result = _persistenceDbContext.Recipes.OrderByDescending(x => x.ReceipeId).FirstOrDefault();

            //compoundingComponents.RecipeId = result.ReceipeId;

            compoundingComponents.RecipeId = compoundingData.RecipeId; //added for test 


            //compoundingComponents.CreatedBy= userId;
            compoundingComponents.CreatedDate = DateTime.Now;

            await _persistenceDbContext.CompoundingComponents.AddAsync(compoundingComponents);
            var saved = await _persistenceDbContext.SaveChangesAsync();

            if (saved <= 0)
            {
                throw new Exception("Component could not be added.");
            }

            return 1;
        }

       

        public async Task<bool> DeleteCompoundingComponents(int id, int? userId)
        {

            var searchCompoundings = await _persistenceDbContext.CompoundingData.Where(x => x.RecipeId == id).ToListAsync();
            var recipe = await _persistenceDbContext.Recipes
                .FirstOrDefaultAsync(r => r.ReceipeId == id);
            foreach (var searchCompounding in searchCompoundings)
            {
                
                var findCompoundingComponentId = await _persistenceDbContext.CompoundingComponents.Where(x => x.CompoundingId == searchCompounding.CompoundingId).ToListAsync();
                var dosagedata=  await _persistenceDbContext.Dosages.Where(x => x.CompoundingId == searchCompounding.CompoundingId).FirstOrDefaultAsync();
                _persistenceDbContext.Remove(dosagedata);
                _persistenceDbContext.RemoveRange(findCompoundingComponentId);
            }
            foreach (var searchCompounding in searchCompoundings)
            {

                var logger = new CompoundLog
            {
                CompoundingId = searchCompounding.CompoundingId,
                RecipeId = searchCompounding.RecipeId,
                ParameterSet = searchCompounding.ParameterSet,
                Date = searchCompounding.Date,
                Notes = "Deleted old compounding data",
                Repetation = searchCompounding.Repetation,
                    PretreatmentDrying = searchCompounding.PretreatmentDrying,
                    PretreatmentNone = searchCompounding.PretreatmentNone,
                    Temperature = searchCompounding.Temperature,
                //Duration = searchCompounding.Duration,
                ResidualIm = searchCompounding.ResidualM,
                NotMeasured = searchCompounding.NotMeasured,
                DeletedBy = userId,
                DeletedDate = DateTime.UtcNow
            };
                await _persistenceDbContext.CompoundLogs.AddAsync(logger);
                await _persistenceDbContext.SaveChangesAsync();
            }



            _persistenceDbContext.RemoveRange(searchCompoundings);
            _persistenceDbContext.Recipes.Remove(recipe);



            var data = await _persistenceDbContext.SaveChangesAsync();
            return true;

             

                }

        public async Task<CompoundingComponent>GetCompoundingComponentsAsync(int id)
        {
            var getData =await _persistenceDbContext.CompoundingComponents.FirstOrDefaultAsync(x => x.Id == id);
            return getData;
        }
        public async Task<IEnumerable<CompoundingComponent>> GetCompoundingComponentsBycompoundingId(int id)
        {
            var getData = await _persistenceDbContext.CompoundingComponents.Where(x => x.CompoundingId == id).ToListAsync();
            return getData;
        }

        public async Task<int> UpdateCompoundingComponents(int compoundId, CompoundingComponent[] compoundingComponents, int? userId)
        {
            var existingData = await _persistenceDbContext.CompoundingComponents.Where(x => x.CompoundingId == compoundId).ToListAsync();
            if (existingData == null)
            {
                throw new NotFoundException($"Compounding Data with ReceipeId {compoundId} not found!");
            }

            _persistenceDbContext.CompoundingComponents.RemoveRange(existingData);


            var compoundingdata = await _persistenceDbContext.CompoundingData.Where(x => x.CompoundingId == compoundId).FirstOrDefaultAsync();

            foreach(var item in compoundingComponents)
            {
                item.CompoundingId = compoundId;
                item.RecipeId = compoundingdata.RecipeId;
                item.CreatedBy = userId;
                item.CreatedDate = DateTime.Now;
                item.ModifiedDate = DateTime.Now;
                item.ModifiedBy = userId;
                 await _persistenceDbContext.CompoundingComponents.AddAsync(item);
                 await _persistenceDbContext.SaveChangesAsync();
            }

            return 1;

           


        }
    }
    }

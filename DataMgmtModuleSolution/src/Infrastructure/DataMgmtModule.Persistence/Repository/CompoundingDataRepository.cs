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
    public class CompoundingDataRepository: ICompoundingData
    {
        private readonly PersistenceDbContext _persistenceDbContext;
        public CompoundingDataRepository(PersistenceDbContext persistenceDbContext)
        {
            _persistenceDbContext = persistenceDbContext;
        }

        public async Task<int>AddCompoundingData(CompoundingDatum compoundingData)
        {
            var result = await _persistenceDbContext.Recipes.OrderByDescending(x => x.ReceipeId).FirstOrDefaultAsync();

            compoundingData.RecipeId = result.ReceipeId;
            var data =await _persistenceDbContext.CompoundingData.AddAsync(compoundingData);
             await _persistenceDbContext.SaveChangesAsync();

            var lastCdata = await _persistenceDbContext.CompoundingData.OrderByDescending(x => x.CompoundingId).FirstOrDefaultAsync();
            if(data==null) 
                return 0;

            else return lastCdata.CompoundingId;
        }

        public async Task<int> DeleteCompoundingDataAsync(int id)
        {
            

            var searchCompounding = await _persistenceDbContext.CompoundingData.Where(x => x.CompoundingId == id).FirstOrDefaultAsync();
            var findCompoundingComponentId = await _persistenceDbContext.CompoundingComponents.Where(x => x.CompoundingId == searchCompounding.CompoundingId).ToListAsync();

            var dosagedata = await _persistenceDbContext.Dosages.Where(x => x.CompoundingId == searchCompounding.CompoundingId).FirstOrDefaultAsync();

            var logger = new CompoundLog
            {
                CompoundingId=searchCompounding.CompoundingId,
                RecipeId = searchCompounding.RecipeId,
                ParameterSet = searchCompounding.ParameterSet,
                Date = searchCompounding.Date,
                Notes = "Deleted old compounding data",
                Repetation = searchCompounding.Repetation,
                Pretreatment = searchCompounding.Pretreatment,
                Temperature = searchCompounding.Temperature,
                Duration = searchCompounding.Duration,
                ResidualIm = searchCompounding.ResidualM, 
                NotMeasured = searchCompounding.NotMeasured,  
                DeletedBy = "admin", 
                DeletedDate = DateTime.UtcNow
            };
            


            await _persistenceDbContext.CompoundLogs.AddAsync(logger);
            _persistenceDbContext.RemoveRange(findCompoundingComponentId);

            _persistenceDbContext.Remove(dosagedata);
            _persistenceDbContext.Remove(searchCompounding);


            var data = await _persistenceDbContext.SaveChangesAsync();
            return 1;



        }

        public Task<CompoundingDatum> GetCompoundingDataAsync(int id)
        {
            var getData = _persistenceDbContext.CompoundingData.FirstOrDefaultAsync(x=>x.CompoundingId==id);

            if (getData == null)
            {
                throw new NotFoundException($"Compounding Data with Id{id} Not Found");
            }
            return getData;

        }

        public async Task<IEnumerable<CompoundingDatum>> GetCompoundingDataByRecipeAsync(int Id)
        {
            var getData =await _persistenceDbContext.CompoundingData.Where(x => x.RecipeId == Id).ToListAsync();
            if (getData == null)
            {
                throw new NotFoundException($"Compounding Data with Id{getData} Not Found");
            }

            return getData;

        }

        public async Task<int> UpdateCompoundingDataAsync(int id, CompoundingDatum compoundingData)
        {
            //var existingData = await _persistenceDbContext.CompoundingData
            //                              .FirstOrDefaultAsync(x => x.ReceipeId == ReceipeId);
            var existingData = await _persistenceDbContext.CompoundingData.FindAsync(id);

            if (existingData == null)
            {
                throw new Exception($"Compounding Data with ReceipeId {id} not found!");
            }



            //compoundingData.ReceipeId = ReceipeId;
            existingData.Pretreatment = compoundingData.Pretreatment;
            existingData.Duration = compoundingData.Duration;
            existingData.Temperature = compoundingData.Temperature;
            existingData.Notes = compoundingData.Notes;
            existingData.ResidualM = compoundingData.ResidualM;
            existingData.NotMeasured = compoundingData.NotMeasured;
            existingData.Date = compoundingData.Date;


            await _persistenceDbContext.SaveChangesAsync();

            return existingData.CompoundingId;
        }
    }
    }


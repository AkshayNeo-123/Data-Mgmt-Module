using DataMgmtModule.Application.Feactures.InjectionMolding.Query.GetByIdInjectionMolding;
using DataMgmtModule.Application.Interface.Persistence;
using DataMgmtModule.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataMgmtModule.Persistence.Repository
{
    public class InjectionMoldingRepository : IInjectionMoldingRepository
    {
        private readonly PersistenceDbContext _dbContext;

        public InjectionMoldingRepository(PersistenceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<InjectionMolding> AddAsync(InjectionMolding entity)
        {
            var recipe = await _dbContext.Recipes.OrderByDescending(x => x.ReceipeId).FirstOrDefaultAsync();
            entity.RecipeId = recipe.ReceipeId;
            _dbContext.InjectionMoldings.Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }



        //public async Task<int> DeleteInjectionMolding(int id)
        //{
        //    var injectionMolding = await _dbContext.InjectionMoldings.FindAsync(id);
        //    if (injectionMolding == null) return 0;

        //    var log = new MouldingLog
        //    {
        //        ProjectId = injectionMolding.ProjectId,
        //        RecipeId = injectionMolding.RecipeId,
        //        ParameterSet = injectionMolding.ParameterSet,
        //        Repetition = injectionMolding.Repetition,
        //        ReferenceAdditive = injectionMolding.ReferenceAdditive,
        //        PreTreatment = injectionMolding.PreTreatment,
        //        DryingTemperature = injectionMolding.DryingTemperature,
        //        DryingTime = injectionMolding.DryingTime,
        //        ResidualMoisture = injectionMolding.ResidualMoisture,
        //        NotMeasured = injectionMolding.NotMeasured,
        //        ProcessingMoisture = injectionMolding.ProcessingMoisture,
        //        PlasticizingVolume = injectionMolding.PlasticizingVolume,
        //        DecompressionVolume = injectionMolding.DecompressionVolume,
        //        SwitchingPoint = injectionMolding.SwitchingPoint,
        //        HoldingPressure = injectionMolding.HoldingPressure,
        //        BackPressure = injectionMolding.BackPressure,
        //        ScrewSpeed = injectionMolding.ScrewSpeed,
        //        InjectionSpeed = injectionMolding.InjectionSpeed,
        //        InjectionPressure = injectionMolding.InjectionPressure,
        //        TemperatureZone = injectionMolding.TemperatureZone,
        //        ExtraFeedSection = injectionMolding.ExtraFeedSection,
        //        MeltTemperature = injectionMolding.MeltTemperature,
        //        NozzleTemperature = injectionMolding.NozzleTemperature,
        //        MoldTemperature = injectionMolding.MoldTemperature,
        //        DeletedBy = "admin",
        //        DeletedDate = DateTime.UtcNow
        //    };

        //    await _dbContext.MouldingLogs.AddAsync(log);
        //    _dbContext.InjectionMoldings.Remove(injectionMolding);

        //    return await _dbContext.SaveChangesAsync();
        //}



        public async Task<IEnumerable<InjectionMolding>> GetAllInjectionMolding()
        {
            return await _dbContext.InjectionMoldings
             .Include(im => im.Project)
             .Include(im => im.Recipe)
             .ToListAsync();
        }

        public async Task<List<InjectionMolding?>> GetByIdInjectionMolding(int id)
        {
            var injectionMoldingList = await _dbContext.InjectionMoldings
                .Where(b => b.RecipeId == id)
                .ToListAsync();

            if (injectionMoldingList == null || !injectionMoldingList.Any())
                throw new Exception($"No Injection Molding records found for Recipe ID {id}.");

            return injectionMoldingList;
        }




        //GetById with Id
        //public async Task<InjectionMolding?> GetByIdInjectionMolding(int id)
        //{
        //    var Injectionmolding = await _dbContext.InjectionMolding.FirstOrDefaultAsync(b => b.Id == id);

        //    if (Injectionmolding == null)
        //        throw new Exception($"Injection Molding with ID {id} not found.");

        //    return Injectionmolding;
        //}

        public async Task<int> UpdateInjectionMolding(int id, InjectionMolding injectionmolding)
        {
            var existingMaterial = await _dbContext.InjectionMoldings.FindAsync(id);
            if (existingMaterial == null)
                throw new Exception($" ID  not found.");




            //existingMaterial.ProjectId = injectionmolding.ProjectId;
            //existingMaterial.RecipeId = injectionmolding.RecipeId;
            //_dbContext.InjectionMolding.Update(injectionmolding);



            existingMaterial.Repetition = injectionmolding.Repetition;
            existingMaterial.ReferenceAdditive = injectionmolding.ReferenceAdditive;
            existingMaterial.ParameterSet = injectionmolding.ParameterSet;
            existingMaterial.PreTreatment = injectionmolding.PreTreatment;
            existingMaterial.DryingTemperature = injectionmolding.DryingTemperature;
            existingMaterial.DryingTime = injectionmolding.DryingTime;
            existingMaterial.ResidualMoisture = injectionmolding.ResidualMoisture;
            existingMaterial.NotMeasured = injectionmolding.NotMeasured;
            existingMaterial.ProcessingMoisture = injectionmolding.ProcessingMoisture;
            existingMaterial.PlasticizingVolume = injectionmolding.PlasticizingVolume;
            existingMaterial.DecompressionVolume = injectionmolding.DecompressionVolume;
            existingMaterial.SwitchingPoint = injectionmolding.SwitchingPoint;
            existingMaterial.HoldingPressure = injectionmolding.HoldingPressure;
            existingMaterial.BackPressure = injectionmolding.BackPressure;
            existingMaterial.ScrewSpeed = injectionmolding.ScrewSpeed;
            existingMaterial.InjectionSpeed = injectionmolding.InjectionSpeed;
            existingMaterial.InjectionPressure = injectionmolding.InjectionPressure;
            existingMaterial.TemperatureZone = injectionmolding.TemperatureZone;
            existingMaterial.ExtraFeedSection = injectionmolding.ExtraFeedSection;
            existingMaterial.MeltTemperature = injectionmolding.MeltTemperature;
            existingMaterial.NozzleTemperature = injectionmolding.NozzleTemperature;
            existingMaterial.MoldTemperature = injectionmolding.MoldTemperature;



            await _dbContext.SaveChangesAsync();
            return existingMaterial.Id;

        }





        public async Task<int> DeleteInjectionMoldingByRecipeId(int RecipeId)
        {
            //var injectionMolding = await _dbContext.InjectionMolding.FindAsync(id);
            var injectionMolding1 = await _dbContext.InjectionMoldings.Where(x => x.RecipeId == RecipeId).ToListAsync();
            if (injectionMolding1 == null) return 0;

            foreach (var injectionMolding in injectionMolding1)
            {

                var log = new MouldingLog
                {

                    ProjectId = injectionMolding.ProjectId,
                    RecipeId = injectionMolding.RecipeId,
                    ParameterSet = injectionMolding.ParameterSet,
                    Repetition = injectionMolding.Repetition,
                    ReferenceAdditive = injectionMolding.ReferenceAdditive,
                    PreTreatment = injectionMolding.PreTreatment,
                    DryingTemperature = injectionMolding.DryingTemperature,
                    DryingTime = injectionMolding.DryingTime,
                    ResidualMoisture = injectionMolding.ResidualMoisture,
                    NotMeasured = injectionMolding.NotMeasured,
                    ProcessingMoisture = injectionMolding.ProcessingMoisture,
                    PlasticizingVolume = injectionMolding.PlasticizingVolume,
                    DecompressionVolume = injectionMolding.DecompressionVolume,
                    SwitchingPoint = injectionMolding.SwitchingPoint,
                    HoldingPressure = injectionMolding.HoldingPressure,
                    BackPressure = injectionMolding.BackPressure,
                    ScrewSpeed = injectionMolding.ScrewSpeed,
                    InjectionSpeed = injectionMolding.InjectionSpeed,
                    InjectionPressure = injectionMolding.InjectionPressure,
                    TemperatureZone = injectionMolding.TemperatureZone,
                    ExtraFeedSection = injectionMolding.ExtraFeedSection,
                    MeltTemperature = injectionMolding.MeltTemperature,
                    NozzleTemperature = injectionMolding.NozzleTemperature,
                    MoldTemperature = injectionMolding.MoldTemperature,
                    DeletedBy = "admin",
                    DeletedDate = DateTime.UtcNow
                };

                await _dbContext.MouldingLogs.AddAsync(log);
                await _dbContext.SaveChangesAsync();

            }
            _dbContext.InjectionMoldings.RemoveRange(injectionMolding1);

            return await _dbContext.SaveChangesAsync();
        }
    }

}



//Delete by recipe id
//public async Task<int> DeleteInjectionMolding(int id)
 //       {
 //           //var injectionMolding = await _dbContext.InjectionMolding.FindAsync(id);
 //           var injectionMolding1 = await _dbContext.InjectionMolding.Where(x => x.RecipeId == id).ToListAsync();
 //           if (injectionMolding1 == null) return 0;

 //           foreach (var injectionMolding in injectionMolding1)
 //           {

 //               var log = new MouldingLog
 //               {

 //                   ProjectId = injectionMolding.ProjectId,
 //                   RecipeId = injectionMolding.RecipeId,
 //                   ParameterSet = injectionMolding.ParameterSet,
 //                   Repetition = injectionMolding.Repetition,
 //                   ReferenceAdditive = injectionMolding.ReferenceAdditive,
 //                   PreTreatment = injectionMolding.PreTreatment ?? 0,
 //                   DryingTemperature = injectionMolding.DryingTemperature,
 //                   DryingTime = injectionMolding.DryingTime,
 //                   ResidualMoisture = injectionMolding.ResidualMoisture,
 //                   NotMeasured = injectionMolding.NotMeasured,
 //                   ProcessingMoisture = injectionMolding.ProcessingMoisture,
 //                   PlasticizingVolume = injectionMolding.PlasticizingVolume,
 //                   DecompressionVolume = injectionMolding.DecompressionVolume,
 //                   SwitchingPoint = injectionMolding.SwitchingPoint,
 //                   HoldingPressure = injectionMolding.HoldingPressure,
 //                   BackPressure = injectionMolding.BackPressure,
 //                   ScrewSpeed = injectionMolding.ScrewSpeed,
 //                   InjectionSpeed = injectionMolding.InjectionSpeed,
 //                   InjectionPressure = injectionMolding.InjectionPressure,
 //                   TemperatureZone = injectionMolding.TemperatureZone,
 //                   ExtraFeedSection = injectionMolding.ExtraFeedSection,
 //                   MeltTemperature = injectionMolding.MeltTemperature,
 //                   NozzleTemperature = injectionMolding.NozzleTemperature,
 //                   MoldTemperature = injectionMolding.MoldTemperature,
 //                   DeletedBy = "admin",
 //                   DeletedDate = DateTime.UtcNow
 //               };

 //               await _dbContext.Moulding_Log.AddAsync(log);
 //               await _dbContext.SaveChangesAsync();

 //           }
 //           _dbContext.InjectionMolding.RemoveRange(injectionMolding1);

 //           return await _dbContext.SaveChangesAsync();
 //       }
 //   }

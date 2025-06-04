
using DataMgmtModule.Application.Exceptions;
using DataMgmtModule.Application.Features.TestFeatures.Commands.UpdateTest;
using DataMgmtModule.Application.Interface.Persistence;
using DataMgmtModule.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataMgmtModule.Persistence.Repository
{
    public class TestRepository : ITestRepository
    {
        readonly PersistenceDbContext _persistenceContext;
        public TestRepository(PersistenceDbContext persistenceContext)
        {
            _persistenceContext = persistenceContext;
        }
        public async Task<IEnumerable<Test>> GetTest()
        {
            return await _persistenceContext.Test.Include(t => t.Recipe).Include(t => t.Recipe.MainPolymer).Where(t => t.IsDelete == false).ToListAsync();
        }

        public async Task<int> AddTest(Test test)
        {
            test.IsDelete = false;
            await _persistenceContext.AddAsync(test);
            return await _persistenceContext.SaveChangesAsync();
        }

        public async Task<Test> FindByIdTest(int id)
        {
            var data = await _persistenceContext.Test.Where(t => t.Id == id).FirstOrDefaultAsync();
            return data;

        }

        //public async Task<int> UpdateTest(Test test)
        //{
        //    var testData = await FindByIdTest(test.Id);
        //    if (testData == null)
        //    {
        //        throw new NotFoundException($"Test Id={test.Id} is not Found!!");
        //    }
        //    testData.RecipeNumber = test.RecipeNumber;
        //    testData.Comment = test.Comment;
        //    testData.IsPublish = test.IsPublish;

        //    return await _persistenceContext.SaveChangesAsync();
        //}

        public async Task<int> UpdateTestWithProperties(UpdateTestCommand request)
        {
            var existingTest = await _persistenceContext.Test
                .Include(t => t.TemperatureProperty)
                .Include(t => t.FlammabilityProperty)
                .Include(t => t.MechanicalProperty)
                .Include(t => t.GeneralProperty)
                .Include(t => t.ElectricalProperty)
                .Include(t => t.Properties)
    .FirstOrDefaultAsync(t => t.Id == request.TestId);

            if (existingTest == null) return 0;

            // Map basic Test data
            existingTest.RecipeNumber = request.Test.RecipeNumber;
            existingTest.Comment = request.Test.Comment;
            existingTest.IsPublish = request.Test.IsPublish;

            // TemperatureProperty
            existingTest.TemperatureProperty.TempHdtA = request.TemperatureProperty.TempHdtA;
            existingTest.TemperatureProperty.TempHdtB = request.TemperatureProperty.TempHdtB;
            existingTest.TemperatureProperty.MeltingTemp = request.TemperatureProperty.MeltingTemp;
            existingTest.TemperatureProperty.CoefficientsParallel = request.TemperatureProperty.CoefficientsParallel;
            existingTest.TemperatureProperty.CoefficientsTransverse = request.TemperatureProperty.CoefficientsTransverse;

            // Repeat for all other nested objects...

            // Save changes
            return await _persistenceContext.SaveChangesAsync();
        }


        public async Task<int> DeleteTest(int id, int deletedBy)
        {
            var testData = await FindByIdTest(id);
            if (testData == null)
            {
                throw new NotFoundException($"Test Id={id} is not Found!!");
            }
            var mechData = await _persistenceContext.MechanicalProperties.Where(t => t.TestId == id && t.IsDelete == false).FirstOrDefaultAsync();
            var genData = await _persistenceContext.GeneralProperties.Where(t => t.TestId == id && t.IsDelete == false).FirstOrDefaultAsync();
            var electricalData = await _persistenceContext.ElectricalProperties.Where(t => t.TestId == id && t.IsDelete == false).FirstOrDefaultAsync();
            var tempData = await _persistenceContext.TemperatureProperties.Where(t => t.TestId == id && t.IsDelete == false).FirstOrDefaultAsync();
            var proData = await _persistenceContext.Properties.Where(t => t.TestId == id && t.IsDelete == false).FirstOrDefaultAsync();
            var flamData = await _persistenceContext.FlammabilityProperties.Where(t => t.TestId == id && t.IsDelete == false).FirstOrDefaultAsync();
            if (mechData != null)
            {
                mechData.IsDelete = true;
                mechData.DeletedBy = deletedBy;
                mechData.DeletedDate = DateTime.Now;
            }
            if (flamData != null)
            {
                flamData.IsDelete = true;
                flamData.DeletedBy = deletedBy;
                flamData.DeletedDate = DateTime.Now;

            }
            if (proData != null)
            {
                proData.IsDelete = true;
                proData.DeletedBy = deletedBy;
                proData.DeletedDate = DateTime.Now;

            }
            if (tempData != null)
            {
                tempData.IsDelete = true;
                tempData.DeletedBy = deletedBy;
                tempData.DeletedDate = DateTime.Now;

            }
            if (electricalData != null)
            {
                electricalData.IsDelete = true;
                electricalData.DeletedBy = deletedBy;
                electricalData.DeletedDate = DateTime.Now;
            }
            if (genData != null)
            {
                genData.IsDelete = true;
                genData.DeletedBy = deletedBy;
                genData.DeletedDate = DateTime.Now;
            }


            testData.IsDelete = true;
            testData.DeletedBy = deletedBy;
            testData.DeletedDate = DateTime.Now;

            return await _persistenceContext.SaveChangesAsync();
        }
        public async Task<IEnumerable<Recipe>> GetRecipedataForAddTest()
        {
            var recipesNotInTests = await _persistenceContext.Recipes
            .Where(r => r.IsDelete == false && !_persistenceContext.Test
                    .Where(t => t.IsDelete == false)
                    .Select(t => t.RecipeNumber)
                    .Contains(r.ReceipeId))
            .ToListAsync();
            return recipesNotInTests;
        }




    }
}

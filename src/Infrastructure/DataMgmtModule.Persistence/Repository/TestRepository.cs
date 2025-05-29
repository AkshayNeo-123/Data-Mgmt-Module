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
    public class TestRepository : ITestRepository
    {
        readonly PersistenceDbContext _persistenceContext;
        public TestRepository(PersistenceDbContext persistenceContext)
        {
            _persistenceContext = persistenceContext;
        }
        public async Task<IEnumerable<Test>> GetTest()
        {
            return await _persistenceContext.Test.Include(t => t.Recipe).Include(t=>t.Recipe.MainPolymer).Where(t => t.IsDelete == false).ToListAsync();
        }

        public async Task<int> AddTest(Test test)
        {
            test.IsDelete=false;
            await _persistenceContext.AddAsync(test);
            return await _persistenceContext.SaveChangesAsync();
        }

        public async Task<Test> FindByIdTest(int id)
        {
            var data=await _persistenceContext.Test.Where(t => t.Id == id).FirstOrDefaultAsync();
            return data;
            
        }

        public async Task<int> UpdateTest(Test test)
        {
            var testData=await FindByIdTest(test.Id);
            if (testData == null)
            {
                throw new NotFoundException($"Test Id={test.Id} is not Found!!");
            }
            testData.RecipeNumber=test.RecipeNumber;
            testData.Comment=test.Comment;
            testData.IsPublish=test.IsPublish;

            return await _persistenceContext.SaveChangesAsync();
        }

        public async Task<int> DeleteTest(int id)
        {
            var testData = await FindByIdTest(id);
            if (testData == null)
            {
                throw new NotFoundException($"Test Id={id} is not Found!!");
            }
            var mechData = await _persistenceContext.MechanicalProperties.Where(t => t.TestId == id).FirstOrDefaultAsync();
            var genData = await _persistenceContext.GeneralProperties.Where(t => t.TestId == id).FirstOrDefaultAsync();
            var electricalData = await _persistenceContext.ElectricalProperties.Where(t => t.TestId == id).FirstOrDefaultAsync();
            var tempData = await _persistenceContext.TemperatureProperties.Where(t => t.TestId == id).FirstOrDefaultAsync();
            var proData = await _persistenceContext.Properties.Where(t => t.TestId == id).FirstOrDefaultAsync();
            var flamData = await _persistenceContext.FlammabilityProperties.Where(t => t.TestId == id).FirstOrDefaultAsync();

            mechData.IsDelete = true;
            genData.IsDelete = true;
            electricalData.IsDelete = true;
            tempData.IsDelete = true;
            proData.IsDelete = true;
            flamData.IsDelete = true;

            testData.IsDelete = true;
            
            return await _persistenceContext.SaveChangesAsync();
        }



        }
}


using DataMgmtModule.Application.Features.TestFeatures.Commands.UpdateTest;
using DataMgmtModule.Domain.Entities;

namespace DataMgmtModule.Application.Interface.Persistence
{
    public interface ITestRepository
    {
        Task<IEnumerable<Test>> GetTest();
        Task<int> AddTest(Test test);
        Task<Test> FindByIdTest(int id);
        Task<int> UpdateTest(Test test);
        Task<int> DeleteTest(int id);

        Task<int> UpdateTestWithProperties(UpdateTestCommand request);
        Task<int> DeleteTest(int id,int deletedBy);
        Task<IEnumerable<Recipe>> GetRecipedataForAddTest();
    }
}

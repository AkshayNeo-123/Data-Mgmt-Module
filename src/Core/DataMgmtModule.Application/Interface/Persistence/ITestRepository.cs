using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Domain.Entities;

namespace DataMgmtModule.Application.Interface.Persistence
{
    public interface ITestRepository
    {
        Task<IEnumerable<Test>> GetTest();
        Task<int> AddTest(Test test);
        Task<Test> FindByIdTest(int id);
        Task<int> UpdateTest(Test test);
        Task<int> DeleteTest(int id,int deletedBy);
    }
}

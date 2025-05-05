using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Domain.Entities;

namespace DataMgmtModule.Application.Interface.Persistence
{
    public interface ICompoundingData
    {
        Task<int> AddCompoundingData(CompoundingDatum compoundingData,int? userId);
        Task<int> DeleteCompoundingDataAsync(int id,int? userId);
        Task<CompoundingDatum>GetCompoundingDataAsync(int id);

        Task<int> UpdateCompoundingDataAsync(int id,CompoundingDatum compoundingData, int? userId);
        Task<IEnumerable<CompoundingDatum>>GetCompoundingDataByRecipeAsync(int id);
        Task<IEnumerable<CompoundingDatum>> GetAllCompoundingDatumAsync();
    }

}

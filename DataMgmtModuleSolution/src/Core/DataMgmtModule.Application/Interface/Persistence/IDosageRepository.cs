using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Domain.Entities;

namespace DataMgmtModule.Application.Interface.Persistence
{
    public interface IDosageRepository
    {
        Task<int> AddDosageAsync(int id, Dosage dosage);
        //Task<Dosage> DeleteDosageAsync(int id);
        Task<Dosage> GetDosageAsync(int id);
        Task<int> UpdateDosageAsync(int id,Dosage dosage);
    }
}

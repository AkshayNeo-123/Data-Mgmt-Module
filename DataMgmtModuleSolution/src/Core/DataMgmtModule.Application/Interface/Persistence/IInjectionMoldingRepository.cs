using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Domain.Entities;

namespace DataMgmtModule.Application.Interface.Persistence
{
   public interface IInjectionMoldingRepository
    {
        Task<IEnumerable<InjectionMolding>> GetAllInjectionMolding();
        Task<InjectionMolding> AddAsync(InjectionMolding entity);
        //Task<int> DeleteInjectionMolding(int id);
        Task<int> UpdateInjectionMolding(int id, InjectionMolding injectionmolding);
        //Task<InjectionMolding?> GetByIdInjectionMolding(int id);
        Task<int> DeleteInjectionMoldingByRecipeId(int RecipeId,int?userId);
        Task<List<InjectionMolding?>> GetByIdInjectionMolding(int id);


    } 
}

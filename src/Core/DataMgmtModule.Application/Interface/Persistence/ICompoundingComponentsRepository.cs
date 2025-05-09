﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Domain.Entities;

namespace DataMgmtModule.Application.Interface.Persistence
{
    public interface ICompoundingComponentsRepository
    {
        Task<int>AddCompoundingComponents(int id, CompoundingComponent compoundingComponents,int? userId);
        Task<bool> DeleteCompoundingComponents(int id,int?userId);
        Task<CompoundingComponent> GetCompoundingComponentsAsync(int id);
        Task<int>UpdateCompoundingComponents(int id,CompoundingComponent[] compoundingComponents,int? userId);
    }
}

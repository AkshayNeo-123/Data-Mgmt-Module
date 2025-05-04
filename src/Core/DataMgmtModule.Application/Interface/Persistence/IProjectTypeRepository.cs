using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Domain.Entities;

namespace DataMgmtModule.Application.Interface.Persistence
{
    public interface IProjectTypeRepository
    {
        Task<IEnumerable<ProjectTypes>> GetAllProjectTypes();
    }
}

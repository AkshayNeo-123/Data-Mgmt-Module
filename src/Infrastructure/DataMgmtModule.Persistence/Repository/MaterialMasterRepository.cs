using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataMgmtModule.Application.Interface.Persistence;
using DataMgmtModule.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataMgmtModule.Persistence.Repository
{
    public class MaterialMasterRepository : IMaterialMasterRepository
    {
        private readonly PersistenceDbContext _context;

        public MaterialMasterRepository(PersistenceDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MvrMfr>> GetAllMvrMfr()
        {
            return await _context.MvrMfr.ToListAsync();
        }

        public async Task<IEnumerable<StorageLocation>> GetAllStorage()
        {
            return await _context.StorageLocation.ToListAsync();
        }
    }
}

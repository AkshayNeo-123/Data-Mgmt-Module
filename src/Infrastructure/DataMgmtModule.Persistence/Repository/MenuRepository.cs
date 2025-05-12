using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Application.Interface.Persistence;
using DataMgmtModule.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataMgmtModule.Persistence.Repository
{
    public class MenuRepository : IMenuRepository
    {
        private readonly PersistenceDbContext _context;
        public MenuRepository(PersistenceDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Menus>> GetMenu()
        {
            return await _context.Menu.ToListAsync();
        }
    }
}

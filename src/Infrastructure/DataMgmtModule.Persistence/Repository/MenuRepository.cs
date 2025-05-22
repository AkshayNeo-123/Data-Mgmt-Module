using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Application.Dtos.Menu;
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
        //public async Task<IEnumerable<Menus>> GetMenu()
        //{
        //    return await _context.Menu
        //        .OrderBy(m=> m.Order)
        //        .ToListAsync();
        //}
        public async Task<IEnumerable<MenuWithChildCountDto>> GetMenu()
        {
            var menuList = await _context.Menu
                .Select(m => new MenuWithChildCountDto
                {
                    Id = m.id,
                    MenuName = m.MenuName,
                    //Path = m.Path,
                    //Icon = m.Icon,
                    Order = m.Order,
                    ParentId = m.ParentId,
                    Route = m.Route,
                    ChildCount = _context.Menu.Count(x => x.ParentId == m.id)
                })
                .OrderBy(m => m.Order)
                .ToListAsync();

            return menuList;
        }
    }
}

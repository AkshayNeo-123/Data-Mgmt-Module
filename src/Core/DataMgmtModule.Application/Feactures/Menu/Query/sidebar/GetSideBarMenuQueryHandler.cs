using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Application.Dtos.Menu;
using DataMgmtModule.Application.Feactures.Menu.Query.sidebar;
using DataMgmtModule.Application.Feactures.RoleManager.Query.GetAllRoles;
using DataMgmtModule.Application.Interface.Persistence;
using DataMgmtModule.Domain.Entities;
using MediatR;

namespace DataMgmtModule.Application.Feactures.Menu.Query.side

{
    public class GetSideBarMenuQueryHandler : IRequestHandler<GetSideBarMenuQuery, IEnumerable<sidebarwithMenu>>
    {
        private IMenuRepository _menuRepository;
        public GetSideBarMenuQueryHandler(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }



        public async Task<IEnumerable<sidebarwithMenu>> Handle(GetSideBarMenuQuery request, CancellationToken cancellationToken)
        {
            var flatMenuList = await _menuRepository.GetMenu();

            // Map MenuWithChildCountDto to sidebarwithMenu  
            var sidebarMenuList = flatMenuList.Select(menu => new sidebarwithMenu
            {
                Id = menu.Id,
                MenuName = menu.MenuName,
                Order = menu.Order,
                ParentId = menu.ParentId,
                ChildCount = menu.ChildCount,
                Route = menu.Route,
                Children = new List<MenuWithChildCountDto>()
            }).ToList();

            var menuDict = sidebarMenuList.ToDictionary(m => m.Id, m => m);

            List<sidebarwithMenu> hierarchicalMenu = new();

            foreach (var menu in sidebarMenuList)
            {
                if (menu.ParentId == 0 || menu.ParentId == null)
                {
                    hierarchicalMenu.Add(menu);
                }
                else if (menuDict.ContainsKey(menu.ParentId.Value))
                {
                    menuDict[menu.ParentId.Value].Children.Add(new MenuWithChildCountDto
                    {
                        Id = menu.Id,
                        MenuName = menu.MenuName,
                        Order = menu.Order,
                        ParentId = menu.ParentId,
                        ChildCount = menu.ChildCount,
                        Route = menu.Route
                    });
                }
            }

            return hierarchicalMenu.OrderBy(m => m.Order);
        }

    }
}

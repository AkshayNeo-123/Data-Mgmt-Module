using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Application.Dtos.Menu;
using DataMgmtModule.Application.Feactures.RoleManager.Query.GetAllRoles;
using DataMgmtModule.Application.Interface.Persistence;
using DataMgmtModule.Domain.Entities;
using MediatR;

namespace DataMgmtModule.Application.Feactures.Menu.Query
{
    public class GetMenuQueryHandler : IRequestHandler<GetMenuQuery, IEnumerable<MenuWithChildCountDto>>
    {
        private IMenuRepository _menuRepository;
        public GetMenuQueryHandler(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        public async Task<IEnumerable<MenuWithChildCountDto>> Handle(GetMenuQuery request, CancellationToken cancellationToken)
        {
            return await _menuRepository.GetMenu();
        }
        //public async Task<IEnumerable<MenuWithChildCountDto>> Handle(GetMenuQuery request, CancellationToken cancellationToken)
        //{
        //    var flatMenuList = await _menuRepository.GetMenu();

        //    var menuDict = flatMenuList.ToDictionary(m => m.Id, m => m);

        //    List<MenuWithChildCountDto> hierarchicalMenu = new();

        //    foreach (var menu in flatMenuList)
        //    {
        //        if (menu.ParentId == 0 || menu.ParentId == null)
        //        {
        //            hierarchicalMenu.Add(menu);
        //        }
        //        else if (menuDict.ContainsKey(menu.ParentId.Value))
        //        {
        //            menuDict[menu.ParentId.Value].Children.Add(menu);
        //        }
        //    }

        //    return hierarchicalMenu.OrderBy(m => m.Order);
        //}
    }
}

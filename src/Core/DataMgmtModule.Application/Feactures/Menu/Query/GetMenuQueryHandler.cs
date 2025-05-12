using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Application.Feactures.RoleManager.Query.GetAllRoles;
using DataMgmtModule.Application.Interface.Persistence;
using DataMgmtModule.Domain.Entities;
using MediatR;

namespace DataMgmtModule.Application.Feactures.Menu.Query
{
    public class GetMenuQueryHandler : IRequestHandler<GetMenuQuery, IEnumerable<Menus>>
    {
        private IMenuRepository _menuRepository;
        public GetMenuQueryHandler(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        public async Task<IEnumerable<Menus>> Handle(GetMenuQuery request, CancellationToken cancellationToken)
        {
            return await _menuRepository.GetMenu();
        }
    }
}

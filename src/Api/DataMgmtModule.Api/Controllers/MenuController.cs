using DataMgmtModule.Application.Feactures.Menu.Query;
using DataMgmtModule.Application.Feactures.Menu.Query.sidebar;
using DataMgmtModule.Application.Feactures.RoleManager.Query.GetAllRoles;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DataMgmtModule.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMediator _mediator;
        public MenuController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetMenu()
        {
            return Ok(await _mediator.Send(new GetMenuQuery()));
        }
        [HttpGet("ForSideBar")]
        public async Task<IActionResult> GetSidebarMenu()
        {
            return Ok(await _mediator.Send(new GetSideBarMenuQuery()));
        }
    }
}

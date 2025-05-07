using DataMgmtModule.Application.Dtos.RoleManagerDto;
using DataMgmtModule.Application.Feactures.RoleManager.Command.CreateRoles;
using DataMgmtModule.Application.Feactures.RoleManager.Command.DeleteRoles;
using DataMgmtModule.Application.Feactures.RoleManager.Command.UpdateRoles;
using DataMgmtModule.Application.Feactures.RoleManager.Query.GetAllRoles;
using DataMgmtModule.Application.Feactures.RoleManager.Query.GetRolesById;
using DataMgmtModule.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DataMgmtModule.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IMediator _mediator;
        public RoleController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllRolesAsync()
        {
            return Ok(await _mediator.Send(new GetAllRolesQuery()));
        }

        [HttpPost]
        public async Task<IActionResult> AddRoleAsync(AddRole addRole)
        {
            var addData = await _mediator.Send(new AddRoleCommand(addRole));
            return Ok(addData);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult>GetRoleByIdAsync(int id)
        {
            return Ok(await _mediator.Send(new GetRolesbyIdQuery(id)));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRoleAsync(int id, UpdateRoleDto updateRole)
        {
            return Ok(await _mediator.Send(new UpdateRoleCommand(id, updateRole)));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRolesAsync(int id)
        {
            return Ok(await _mediator.Send(new DeleteRolesByIdCommand(id)));
        }

    }
}

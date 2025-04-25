
using MediatR;
using Microsoft.AspNetCore.Mvc;
using DataMgmtModule.Application.Features.RolePermissions.DTOs;
using DataMgmtModule.Application.Features.RolePermissions.Commands.CreateRolePermission;
using DataMgmtModule.Application.Features.RolePermissions.Queries.GetAllRolePermissions;
using DataMgmtModule.Application.Features.RolePermissions.Commands.UpdateRolePermission;
using DataMgmtModule.Application.Features.RolePermissions.Commands.DeleteRolePermission;
using DataMgmtModule.Application.Features.RolePermissions.Queries.GetById;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RolePermissionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RolePermissionsController(IMediator mediator)
        {
            _mediator = mediator;
        }



        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllRolePermissionsQuery());
            return Ok(result);
        }



        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RolePermissionDto rolePermissionDto)
        {
            if (rolePermissionDto == null)
                return BadRequest("Invalid payload");

            var command = new CreateRolePermissionCommand(rolePermissionDto);
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromQuery]int id, [FromBody] RolePermissionDto dto)
        {
            var command = new UpdateRolePermissionCommand(id, dto);
            var result = await _mediator.Send(command);

            if (result == null)
                return NotFound();

            return Ok(result);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteRolePermissionCommand(id));
            return NoContent();
        }



    }
}

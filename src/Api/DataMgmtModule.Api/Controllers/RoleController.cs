using System.Data;
using DataMgmtModule.Application.Dtos.RoleManagerDto;
using DataMgmtModule.Application.Feactures.RoleManager.Command.CreateRoles;
using DataMgmtModule.Application.Feactures.RoleManager.Command.DeleteRoles;
using DataMgmtModule.Application.Feactures.RoleManager.Command.UpdateRoles;
using DataMgmtModule.Application.Feactures.RoleManager.Query.GetAllRoles;
using DataMgmtModule.Application.Feactures.RoleManager.Query.GetRolesById;
using DataMgmtModule.Domain.Entities;
using DataMgmtModule.Persistence;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DataMgmtModule.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly PersistenceDbContext _context;
        public RoleController(IMediator mediator, PersistenceDbContext context)
        {
            _mediator = mediator;
            _context = context;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllRolesAsync()
        {
            return Ok(await _mediator.Send(new GetAllRolesQuery()));
        }

        //[HttpPost]
        //public async Task<IActionResult> AddRoleAsync(AddRole addRole)
        //{
        //    var addData = await _mediator.Send(new AddRoleCommand(addRole));
        //    return Ok(addData);
        //}

        [HttpPost]
        public async Task<IActionResult> AddRoleAsync(AddRole addRole)
        {
            var role = new Roles { RoleName = addRole.RoleName };
            _context.Roles.Add(role);
            await _context.SaveChangesAsync();

            foreach (var entry in addRole.Permissions)
            {
                var menuId = entry.Key;
                var perm = entry.Value;

                var rolePermission = new RolePermission
                {
                    RoleId = role.RoleId,
                    MenuId = menuId,
                    CanView = perm.View,
                    CanCreate = perm.Create,
                    CanEdit = perm.Update,
                    CanDelete = perm.Delete
                };

                _context.RolePermissions.Add(rolePermission);
            }

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult>GetRoleByIdAsync(int id)
        {
            return Ok(await _mediator.Send(new GetRolesbyIdQuery(id)));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRoleAsync(int id, AddRole updateRole)
        {
            var findRole = await _context.Roles.FirstOrDefaultAsync(r=>r.RoleId==id);
            findRole.RoleName = updateRole.RoleName;
            //var role = new Roles { RoleName = updateRole.RoleName };
            _context.Roles.Update(findRole);
            await _context.SaveChangesAsync();

            foreach (var entry in updateRole.Permissions)
            {
                var menuId = entry.Key;
                var perm = entry.Value;

                var editPermission = _context.RolePermissions.FirstOrDefault(r => r.MenuId == menuId && r.RoleId == findRole.RoleId);
                //editPermission.RoleId=findRole.RoleId; editPermission.MenuId=menuId;
                editPermission.CanView = perm.View;
                editPermission.CanDelete = perm.Delete;
                editPermission.CanCreate = perm.Create;
                editPermission.CanEdit = perm.Update;

                //var rolePermission = new RolePermission
                //{
                //    RoleId = findRole.RoleId,
                //    MenuId = menuId,
                //    CanView = perm.View,
                //    CanCreate = perm.Create,
                //    CanEdit = perm.Update,
                //    CanDelete = perm.Delete
                //};

                _context.RolePermissions.Update(editPermission);
            }

            await _context.SaveChangesAsync();

            return Ok();
            //return Ok(await _mediator.Send(new UpdateRoleCommand(id, updateRole)));
        }

        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateRoleAsync(int id, [FromBody] UpdateRoleDto dto)
        //{
        //    var role = await _context.Roles
        //        .Include(r => r.RolePermissions)
        //        .FirstOrDefaultAsync(r => r.RoleId == id);

        //    if (role == null)
        //        return NotFound();

        //    role.RoleName = dto.RoleName;

        //    // Remove existing permissions
        //    _context.RolePermissions.RemoveRange(role.RolePermissions);

        //    // Add updated permissions
        //    var newPermissions = dto.Permissions.Select(p => new RolePermission
        //    {
        //        RoleId = id,
        //        MenuId = p.MenuId,
        //        CanView = p.CanView,
        //        CanCreate = p.CanCreate,
        //        CanEdit = p.CanEdit,
        //        CanDelete = p.CanDelete
        //    });

        //    await _context.RolePermissions.AddRangeAsync(newPermissions);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRolesAsync(int id)
        {
            return Ok(await _mediator.Send(new DeleteRolesByIdCommand(id)));
        }

    }
}

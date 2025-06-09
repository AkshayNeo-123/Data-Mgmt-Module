using System.Data;
using DataMgmtModule.Application.Dtos.RoleManagerDto;
using DataMgmtModule.Application.Feactures.RoleManager.Command.CreateRoles;
using DataMgmtModule.Application.Feactures.RoleManager.Command.DeleteRoles;
using DataMgmtModule.Application.Feactures.RoleManager.Command.UpdateRoles;
using DataMgmtModule.Application.Feactures.RoleManager.Query.GetAllRoles;
using DataMgmtModule.Application.Feactures.RoleManager.Query.GetRolesById;
using DataMgmtModule.Application.Interface.Persistence;
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
        private readonly IRoleRepository _roleRepo;
        public RoleController(IMediator mediator, PersistenceDbContext context, IRoleRepository roleRepo)
        {
            _mediator = mediator;
            _context = context;
            _roleRepo = roleRepo;
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

        //[HttpPost]
        //public async Task<IActionResult> AddRoleAsync(AddRole addRole)
        //{
        //    var role = new Roles { RoleName = addRole.RoleName };
        //    _context.Roles.Add(role);
        //    await _context.SaveChangesAsync();

        //    foreach (var entry in addRole.Permissions)
        //    {
        //        var menuId = entry.Key;
        //        var perm = entry.Value;

        //        var rolePermission = new RolePermission
        //        {
        //            RoleId = role.RoleId,
        //            MenuId = menuId,
        //            CanView = perm.View,
        //            CanCreate = perm.Create,
        //            CanEdit = perm.Update,
        //            CanDelete = perm.Delete
        //        };

        //        _context.RolePermissions.Add(rolePermission);
        //    }

        //    await _context.SaveChangesAsync();

        //    return Ok();
        //}

        
        [HttpPost]
        public async Task<IActionResult> AddRoleAsync(AddRole addRole)
        {
            try
            {
                var existingRole = await _context.Roles
                    .FirstOrDefaultAsync(r => r.RoleName == addRole.RoleName);

                if (existingRole != null)
                {
                    return BadRequest(new { message = "Role name already exists." });
                }

                var role = await _roleRepo.AddRolesAsync(new Roles { RoleName = addRole.RoleName });

                var rolePermissionsList = new List<RolePermission>();
                var menuList = await _context.Menu.ToListAsync();

                int countCanView = 0;
                int countofcanviedforuser = 0;

                foreach (var entry in addRole.Permissions)
                {
                    var menuId = entry.Key;
                    var perm = entry.Value;

                    // Track count for special parents
                    var menu = menuList.FirstOrDefault(m => m.id == menuId);

                    if (menu?.ParentId == 1 && perm.View)
                    {
                        countCanView++;
                    }
                    if (menu?.ParentId == 12 && perm.View)
                    {
                        countofcanviedforuser++;
                    }

                    var rolePermission = new RolePermission
                    {
                        RoleId = role.RoleId,
                        MenuId = menuId,
                        CanView = perm.View,
                        CanCreate = perm.Create,
                        CanEdit = perm.Update,
                        CanDelete = perm.Delete
                    };

                    rolePermissionsList.Add(rolePermission);
                }

                var permissionDict = rolePermissionsList.ToDictionary(rp => rp.MenuId);

                // Ensure parent MenuId = 1 (parent of dashboard?) gets CanView = true if any child has it
                if (!permissionDict.ContainsKey(1))
                {
                    permissionDict[1] = new RolePermission
                    {
                        RoleId = role.RoleId,
                        MenuId = 1,
                        CanView = countCanView > 0,
                        CanCreate = false,
                        CanEdit = false,
                        CanDelete = false
                    };
                }
                else
                {
                    permissionDict[1].CanView = countCanView > 0;
                }

                if (!permissionDict.ContainsKey(12))
                {
                    permissionDict[12] = new RolePermission
                    {
                        RoleId = role.RoleId,
                        MenuId = 12,
                        CanView = countofcanviedforuser > 0,
                        CanCreate = false,
                        CanEdit = false,
                        CanDelete = false
                    };
                }
                else
                {
                    permissionDict[12].CanView = countofcanviedforuser > 0;
                }

                // Add all RolePermissions to DB
                foreach (var perm in permissionDict.Values)
                {
                    _context.RolePermissions.Add(perm);
                }

                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }


        [HttpGet("{id}")]
        public async Task<IActionResult>GetRoleByIdAsync(int id)
        {
            return Ok(await _mediator.Send(new GetRolesbyIdQuery(id)));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRoleAsync(int id, AddRole updateRole)
        {
            var countCanView = 0;
            var countofcanviedforuser = 0;
            bool check = false;
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
                if (editPermission != null) { 
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
                    var checkMenu = _context.Menu.Where(e => e.id == editPermission.MenuId && e.ParentId == 1).FirstOrDefaultAsync();
                    if (checkMenu.Result != null)
                    {
                        check = true;
                    }
                    if (check && editPermission.CanView == true)
                    {
                        countCanView++;
                    }
                    check = false;

                    var checkMenuforUser =await _context.Menu.Where(e => e.id == editPermission.MenuId && e.ParentId == 12).FirstOrDefaultAsync();
                    if (checkMenuforUser != null)
                    {
                        check = true;
                    }
                    if (check && editPermission.CanView == true)
                    {
                        countofcanviedforuser++;
                    }
                    check = false;
                _context.RolePermissions.Update(editPermission);
                }
                else
                {
                    var rolePermission = new RolePermission
                    {
                        RoleId = findRole.RoleId,
                        MenuId = menuId,
                        CanView = perm.View,
                        CanCreate = perm.Create,
                        CanEdit = perm.Update,
                        CanDelete = perm.Delete
                    };

                    
                        _context.RolePermissions.Add(rolePermission);
                }
            }

            foreach (var entry in updateRole.Permissions)
            {
                var menuId = entry.Key;
                var perm = entry.Value;

                var editPermission = _context.RolePermissions.FirstOrDefault(r => r.MenuId == menuId && r.RoleId == findRole.RoleId);
                if (editPermission != null)
                {
                    if (editPermission.MenuId == 1 && countCanView == 0)
                    {
                        editPermission.CanView = false;
                    }
                    if (editPermission.MenuId == 1 && countCanView > 0)
                    {
                        editPermission.CanView = true;
                        countCanView = 0;
                    }
                    if (editPermission.MenuId == 12 && countofcanviedforuser == 0)
                    {
                        editPermission.CanView = false;
                    }
                    if (editPermission.MenuId == 12 && countofcanviedforuser > 0)
                    {
                        editPermission.CanView = true;
                        countofcanviedforuser = 0;
                    }
                }
            }
            //countCanView = 0;
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

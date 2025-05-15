using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataMgmtModule.Application.Dtos.RoleManagerDto;
using DataMgmtModule.Application.Exceptions;
using DataMgmtModule.Application.Features.RolePermissions.DTOs;
using DataMgmtModule.Application.Interface.Persistence;
using DataMgmtModule.Domain.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DataMgmtModule.Persistence.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly PersistenceDbContext _context;
        private readonly IMapper _mapper;
        public RoleRepository(PersistenceDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Roles> AddRolesAsync(Roles roles)
        {
            // Check if the role name already exists (case-insensitive)
            bool roleExists = await _context.Roles
                .AnyAsync(r => r.RoleName.ToLower().Trim() == roles.RoleName.ToLower().Trim());

            if (roleExists)
            {
                // You can either throw an exception or return null / custom response
                throw new Exception("Role name already exists.");
            }
             await _context.Roles.AddAsync(roles);
             await _context.SaveChangesAsync();
            return roles;
        }

        public async Task<Roles> DeleteAccountByIdAsync(int id)
        {
            var getdata = await _context.Roles.FindAsync(id);
            if(getdata == null)
            {
                throw new NotFoundException($"Id not found{id}");
            }
            var getPermissionData = await _context.RolePermissions.Where(r => r.RoleId == id).ToListAsync();
            _context.RolePermissions.RemoveRange(getPermissionData);
            _context.Remove(getdata);
            await _context.SaveChangesAsync();
            return getdata;
        }

        public async Task<IEnumerable<GetRoleDto>> GetAllRoles()
        {
            var data = _context.Roles.Select(z => new GetRoleDto
            {
                RoleId = z.RoleId,
                RoleName = z.RoleName
            }).ToList();
            data.ForEach(x => x.RolePermissions = _mapper.Map<List<RolePermissionDto>>(_context.RolePermissions.Where(z => z.RoleId == x.RoleId).ToList()));
            return data;
        }

        //public async Task<IEnumerable<GetRoleDto>> GetAllRoles()
        //{
        //    var data = _context.Roles.Select(z => new GetRoleDto
        //    {
        //        RoleId = z.RoleId,
        //        RoleName = z.RoleName
        //    }).ToList();

        //    data.ForEach(x =>
        //    {
        //        var permissions = _context.RolePermissions
        //            .Where(rp => rp.RoleId == x.RoleId)
        //            .Join(
        //                _context.Menus,
        //                rp => rp.MenuId,
        //                m => m.MenuId,
        //                (rp, m) => new RolePermissionDto
        //                {
        //                    RoleId = rp.RoleId,
        //                    MenuId = rp.MenuId,
        //                    CanView = rp.CanView,
        //                    CanCreate = rp.CanCreate,
        //                    CanEdit = rp.CanEdit,
        //                    CanDelete = rp.CanDelete,
        //                    MenuName = m.MenuName
        //                })
        //            .ToList();

        //        x.RolePermissions = permissions;
        //    });

        //    return data;
        //}

        //public async Task<GetRoleDto?>GetRolesByIdAsync(int id)
        //{
        //    //var getData = await _context.Roles.FirstOrDefaultAsync(x => x.RoleId == id);
        //    //return getData;
        //    //var data = _context.Roles.Select(z => new GetRoleDto
        //    //{
        //    //    RoleId = z.RoleId,
        //    //    RoleName = z.RoleName
        //    //}).ToList();
        //    //data.ForEach(x => x.RolePermissions = _mapper.Map<List<RolePermissionDto>>(_context.RolePermissions.Where(z => z.RoleId == x.RoleId).ToList()));
        //    //return data;
        //    var roleEntity = await _context.Roles
        //.FirstOrDefaultAsync(x => x.RoleId == id);

        //    if (roleEntity == null)
        //        return null;

        //    var dto = new GetRoleDto
        //    {
        //        RoleId = roleEntity.RoleId,
        //        RoleName = roleEntity.RoleName
        //    };

        //    dto.RolePermissions = _mapper.Map<List<RolePermissionDto>>(
        //        await _context.RolePermissions
        //            .Where(rp => rp.RoleId == roleEntity.RoleId)
        //            .ToListAsync()
        //    );

        //    return dto;
        //}

        public async Task<GetRoleDto?> GetRolesByIdAsync(int id)
        {
            var roleEntity = await _context.Roles.FirstOrDefaultAsync(x => x.RoleId == id);

            if (roleEntity == null)
                return null;

            var dto = new GetRoleDto
            {
                RoleId = roleEntity.RoleId,
                RoleName = roleEntity.RoleName
            };

            dto.RolePermissions = await (
                from rp in _context.RolePermissions
                join m in _context.Menu on rp.MenuId equals m.id
                where rp.RoleId == roleEntity.RoleId
                select new RolePermissionDto
                {
                    RoleId = rp.RoleId,
                    MenuId = rp.MenuId,
                    MenuName = m.MenuName, 
                    CanView = rp.CanView,
                    CanCreate = rp.CanCreate,
                    CanEdit = rp.CanEdit,
                    CanDelete = rp.CanDelete
                }).ToListAsync();

            return dto;
        }

        public async Task<GetRoleDto> UpdateRolesAsync(int id, GetRoleDto roles)
        {
            var getData = await _context.Roles.FindAsync(id);
            _context.Update(getData);
            await _context.SaveChangesAsync();
            return roles;
        }
    }
}

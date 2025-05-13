using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataMgmtModule.Application.Dtos.RoleManagerDto;
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

             await _context.Roles.AddAsync(roles);
           await _context.SaveChangesAsync();
            return roles;
        }

        public async Task<Roles> DeleteAccountByIdAsync(int id)
        {
            //var getPermissionData = await _context.RolePermissions.Where(r => r.RoleId == roleId).ToListAsync();
            //_context.RolePermissions.RemoveRange(getPermissionData);
            var getdata = await _context.Roles.FindAsync(id);
            _context.Remove(getdata);
            await _context.SaveChangesAsync();
            return getdata;
        }

        public async Task<IEnumerable<GetRoleDto>> GetAllRoles()
        {
            var data = _context.Roles.Select(z=> new GetRoleDto
            {
                RoleId = z.RoleId,
                RoleName = z.RoleName
            }).ToList();
            data.ForEach(x => x.RolePermissions =_mapper.Map<List<RolePermissionDto>>( _context.RolePermissions.Where(z => z.RoleId == x.RoleId).ToList()));
            return data;
        }
            
        public async Task<GetRoleDto?>GetRolesByIdAsync(int id)
        {
            //var getData = await _context.Roles.FirstOrDefaultAsync(x => x.RoleId == id);
            //return getData;
            //var data = _context.Roles.Select(z => new GetRoleDto
            //{
            //    RoleId = z.RoleId,
            //    RoleName = z.RoleName
            //}).ToList();
            //data.ForEach(x => x.RolePermissions = _mapper.Map<List<RolePermissionDto>>(_context.RolePermissions.Where(z => z.RoleId == x.RoleId).ToList()));
            //return data;
            var roleEntity = await _context.Roles
        .FirstOrDefaultAsync(x => x.RoleId == id);

            if (roleEntity == null)
                return null;

            var dto = new GetRoleDto
            {
                RoleId = roleEntity.RoleId,
                RoleName = roleEntity.RoleName
            };

            dto.RolePermissions = _mapper.Map<List<RolePermissionDto>>(
                await _context.RolePermissions
                    .Where(rp => rp.RoleId == roleEntity.RoleId)
                    .ToListAsync()
            );

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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Application.Features.RolePermissions.DTOs;
using DataMgmtModule.Domain.Entities;

namespace DataMgmtModule.Application.Dtos.RoleManagerDto
{
    public class GetRoleDto
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; } = null!;
        public List<RolePermissionDto> RolePermissions { get; set; }
    }
}

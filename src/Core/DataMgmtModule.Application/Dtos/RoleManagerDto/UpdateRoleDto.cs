using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DataMgmtModule.Application.Feactures.RoleManager.Command.CreateRoles.AddRole;

namespace DataMgmtModule.Application.Dtos.RoleManagerDto
{
    public class UpdateRoleDto
    {
        public string RoleName { get; set; }
        public Dictionary<int, PermissionDto> Permissions { get; set; }

        public class PermissionDto
        {
            public bool View { get; set; }
            public bool Create { get; set; }
            public bool Update { get; set; }
            public bool Delete { get; set; }
        }
        //public string RoleName { get; set; }
        //public List<PermissionDto> Permissions { get; set; }
        //public string Description { get; set; }
        //public bool RoleManagement { get; set; }
        //public bool UserManagement { get; set; }
        //public bool Materials { get; set; }
        //public bool Project { get; set; }
        //public bool Recipe { get; set; }
        //public bool Testing { get; set; }
        //public bool Dashboard { get; set; }
        //public bool MasterTables { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMgmtModule.Application.Feactures.RoleManager.Command.CreateRoles
{
    public class AddRole
    {
        public string RoleName { get; set; }
        public string Description { get; set; }
        public bool RoleManagement { get; set; }
        public bool UserManagement { get; set; }
        public bool Materials { get; set; }
        public bool Project { get; set; }
        public bool Recipe { get; set; }
        public bool Testing { get; set; }
        public bool Dashboard { get; set; }
        public bool MasterTables { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace DataMgmtModule.Domain.Entities;

public partial class Roles
{
    public int RoleId { get; set; }

    public string RoleName { get; set; } = null!;

    public string? Description { get; set; }
    public bool RoleManagement { get; set; }
    public bool UserManagement { get; set; }
    public bool Materials { get; set; }
    public bool Project { get; set; }
    public bool Recipe { get; set; }
    public bool Testing { get; set; }
    public bool Dashboard { get; set; }
    public bool MasterTables { get; set; }

    public virtual ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();

    ////public virtual ICollection<User> Users { get; set; } = new List<User>();
}

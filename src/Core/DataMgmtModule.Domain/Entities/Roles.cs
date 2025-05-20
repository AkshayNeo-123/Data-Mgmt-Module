using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataMgmtModule.Domain.Entities;

public partial class Roles
{
    public int RoleId { get; set; }

    public string RoleName { get; set; } = null!;
    //[NotMapped]
    //public  ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();

    ////public virtual ICollection<User> Users { get; set; } = new List<User>();
}


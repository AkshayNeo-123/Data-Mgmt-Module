﻿using System;
using System.Collections.Generic;

namespace DataMgmtModule.Domain.Entities;

public partial class RolePermission
{
    public int PermissionId { get; set; }

    public int? RoleId { get; set; }

    public string? ModuleName { get; set; }

    public bool CanView { get; set; }

    public bool CanCreate { get; set; }

    public bool CanEdit { get; set; }

    public bool CanDelete { get; set; }

    public virtual Roles? Role { get; set; }
}

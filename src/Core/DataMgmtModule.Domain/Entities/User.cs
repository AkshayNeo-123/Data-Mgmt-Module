using System;
using System.Collections.Generic;

namespace DataMgmtModule.Domain.Entities;

public partial class User
{
    public int UserId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string Email { get; set; } = null!;

    public string? PasswordHash { get; set; }

    public string? Phone { get; set; }

    public int? RoleId { get; set; }

    public string? Status { get; set; }

    public DateTime? CreatedDate { get; set; }

    public virtual Roles? Role { get; set; }
}

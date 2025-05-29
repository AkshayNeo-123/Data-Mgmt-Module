using System;
using System.Collections.Generic;

namespace DataMgmtModule.Domain.Entities;

public partial class User : Common
{
    public int UserId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string Email { get; set; } = null!;

    public string? PasswordHash { get; set; }
    public string? Phone { get; set; }

    public int? RoleId { get; set; }

    public string? Status { get; set; }

    public virtual Roles? Role { get; set; }
    public bool isDelete { get; set; } = false;
    public string? Otp { get; set; }
    public DateTime? OtpExpiry { get; set; }
    public bool OtpVerified { get; set; } = false;
}

using System;
using System.Collections.Generic;

namespace DataMgmtModule.Domain.Entities;

public partial class Contact
{
    public int ContactId { get; set; }

    public string ContactName { get; set; } = null!;

    public int ContactType { get; set; }

    public string AddressLine1 { get; set; } = null!;

    public string? AddressLine2 { get; set; }

    public string City { get; set; } = null!;

    public string State { get; set; } = null!;

    public int Zip { get; set; }

    public string Email { get; set; } = null!;

    public string? Phone { get; set; }

    public virtual ICollection<Materials> Materials { get; set; } = new List<Materials>();
}

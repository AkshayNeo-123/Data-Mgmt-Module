using System;
using System.Collections.Generic;
using DataMgmtModule.Domain.Enum.ContactEnum;

namespace DataMgmtModule.Domain.Entities;

public partial class Contact
{
    public int ContactId { get; set; }

    public string ContactName { get; set; } = null!;

    public ContactTypes ContactType { get; set; }

    public string AddressLine1 { get; set; } = null!;

    public string? AddressLine2 { get; set; }

    public int? CityId { get; set; }
    public Cities? Cities { get; set; }
    public int StateId { get; set; }
    public States? States { get; set; } = null!;
    public int Zip { get; set; }

    public string Email { get; set; } = null!;

    public string? Phone { get; set; }
    public bool? IsDelete { get; set; }
    public int? CreatedBy { get; set; }
    public int? ModifiedBy { get; set; }
    public DateTime? CreatedDate { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public DateTime? DeletedDate { get; set; }
    public int? DeletedBy{get;set;}

    //public virtual ICollection<Materials>? Materials { get; set; } = new List<Materials>();
}

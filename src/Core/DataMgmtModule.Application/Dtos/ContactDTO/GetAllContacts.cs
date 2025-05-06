using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Domain.Entities;

namespace DataMgmtModule.Application.Dtos.ContactDTO
{
  public  class GetAllContacts
    {
        public int ContactId { get; set; }
        public string ContactName { get; set; } = null!;

        public int ContactType { get; set; }

        public string AddressLine1 { get; set; } = null!;

        public string? AddressLine2 { get; set; }

        public string City { get; set; } = null!;

        public int? StateId { get; set; }
        public States States { get; set; }
        public int Zip { get; set; }

        public string Email { get; set; } = null!;

        public string? Phone { get; set; }
        public bool isDelete { get; set; }
    }
    
}

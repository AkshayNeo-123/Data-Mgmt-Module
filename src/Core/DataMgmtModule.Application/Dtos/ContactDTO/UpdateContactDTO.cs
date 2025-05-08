using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Domain.Enum.ContactEnum;

namespace DataMgmtModule.Application.Dtos.ContactDTO
{
    public class UpdateContactDTO
    {
        public string ContactName { get; set; } = null!;

        public ContactTypes ContactType { get; set; }

        public string AddressLine1 { get; set; } = null!;

        public string? AddressLine2 { get; set; }


        public int StateId { get; set; }

        public int CityId { get; set; }
        public int Zip { get; set; }

        public string Email { get; set; } = null!;

        public string? Phone { get; set; }
        //public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
        //public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}


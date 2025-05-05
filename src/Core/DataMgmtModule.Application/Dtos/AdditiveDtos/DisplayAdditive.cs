using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMgmtModule.Application.Dtos.AdditiveDtos
{
    public class DisplayAdditive
    {
        public int Id { get; set; }

        public string AdditiveName { get; set; } = null!;
        public bool isDelete { get; set; }

        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}

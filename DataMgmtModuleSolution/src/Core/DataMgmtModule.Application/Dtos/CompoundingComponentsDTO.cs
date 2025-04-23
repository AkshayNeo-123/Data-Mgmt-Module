using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Domain.Entities;

namespace DataMgmtModule.Application.Dtos
{
    public class CompoundingComponentsDTO
    {
        //public int CompoundingId { get; set; }
        public int ComponentId { get; set; }
        public decimal Share { get; set; }
        public bool MF { get; set; }
        public bool _2ndF { get; set; }
        public bool SF { get; set; }
        public bool A { get; set; }
        public bool B { get; set; }
        public bool C { get; set; }
        public bool D { get; set; }
        public bool E { get; set; }
        public bool F { get; set; }



    }
}

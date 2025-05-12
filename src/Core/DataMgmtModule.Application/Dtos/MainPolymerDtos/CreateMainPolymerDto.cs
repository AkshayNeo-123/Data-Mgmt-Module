using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMgmtModule.Application.Dtos.MainPolymerDtos
{
    public class CreateMainPolymerDto
    {
       
        public string PolymerName { get; set; }
         public int? CreatedBy { get; set; }
        //public int? ModifiedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
      

        
    }
}

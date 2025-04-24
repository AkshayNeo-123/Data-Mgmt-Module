using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Domain.Entities;

namespace DataMgmtModule.Application.Dtos.RecipeDtos
{
    public class GetAllRecipeDtos
    {
        //public int ReceipeId { get; set; }
        public string ProductName { get; set; }
        public string Comments { get; set; }
        public int ProjectId { get; set; }
        public DateTime CreatedDate { get; set; }

        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int AdditiveId { get; set; }
        public int MainPolymerId { get; set; }
        //public string AdditiveName { get; set; }

    }
}

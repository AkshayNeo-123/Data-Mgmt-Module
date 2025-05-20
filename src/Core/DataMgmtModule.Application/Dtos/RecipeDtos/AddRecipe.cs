using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Domain.Entities;

namespace DataMgmtModule.Application.Dtos.RecipeDtos
{
    public class AddRecipe:Common
    {
        
        public string ProductName { get; set; }
        public string Comments { get; set; }
        public int ProjectId { get; set; }
        public int AdditiveId { get; set; }
        public int MainPolymerId { get; set; }
    }
}

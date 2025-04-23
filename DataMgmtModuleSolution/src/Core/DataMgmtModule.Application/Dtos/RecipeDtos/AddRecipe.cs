using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMgmtModule.Application.Dtos.RecipeDtos
{
    public class AddRecipe
    {
        
        public string ProductName { get; set; }
        public string Comments { get; set; }
        public int ProjectId { get; set; }
        public int AdditiveId { get; set; }
        public int MainPolymerId { get; set; }
    }
}

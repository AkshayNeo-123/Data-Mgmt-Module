using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMgmtModule.Application.Dtos.RecipeDtos
{
    public class RecipeProjectDTO
    {
        public int RecipeId { get; set; }
        public string? ProductName { get; set; }
        public string ProjectNumber { get; set; }
        public string Description { get; set; }
    }
}

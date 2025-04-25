using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Application.Dtos.RecipeComponentDtos;
using DataMgmtModule.Application.Dtos.RecipeDtos;

namespace DataMgmtModule.Application.Dtos.CommonDto
{
    public class RecipeandComponent
    {
        public AddRecipe Recipe { get; set; }
        public AddRecipeComponentDto[] Component { get; set; }
        
    }
}

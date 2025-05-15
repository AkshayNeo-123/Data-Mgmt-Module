using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMgmtModule.Application.Dtos.RecipeComponentDtos
{
    public class AddRecipeComponentDto
    {
        public int ComponentId { get; set; }
        public decimal? WtPercent { get; set; }
        public decimal? ValPercent { get; set; }
        public decimal? Density { get; set; }
        public bool MP { get; set; }
        public bool MF { get; set; }
        public int? TypeId { get; set; }

    }
}

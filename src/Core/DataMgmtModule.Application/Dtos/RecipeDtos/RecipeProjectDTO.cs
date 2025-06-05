using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Domain.Entities;

namespace DataMgmtModule.Application.Dtos.RecipeDtos
{
    public class RecipeProjectDTO
    {
        public int RecipeId { get; set; }
        public string? ProductName { get; set; }
        public string ProjectNumber { get; set; }
        public string Description { get; set; }
        public decimal? TensileModulus_DAM { get; set; }
        public decimal? CharpyImpact_DAM { get; set; }
        public decimal? FlexuralStrength_DAM { get; set; }
        public Test Tests { get; set; }


    }
}

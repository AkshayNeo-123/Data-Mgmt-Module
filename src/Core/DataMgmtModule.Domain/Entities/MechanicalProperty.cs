using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMgmtModule.Domain.Entities
{
    public class MechanicalProperty :CommonTest
    {
        [Key]
        public int Id { get; set; }
        public int TestId { get; set; }

        // Tensile
        public decimal? TensileModulus_DAM { get; set; }
        public decimal? TensileModulus_Conditioned { get; set; }
        public decimal? TensileModulus_Conditioned_Mm_Min { get; set; }

        public decimal? StressAtYield_DAM { get; set; }
        public decimal? StressAtYield_Conditioned { get; set; }
        public decimal? StressAtYield_Conditioned_Mm_Min { get; set; }

        public decimal? StrainAtYield_DAM { get; set; }
        public decimal? StrainAtYield_Conditioned { get; set; }
        public decimal? StrainAtYield_Conditioned_Mm_Min { get; set; }

        public decimal? StrainAtBreak_DAM { get; set; }
        public decimal? StrainAtBreak_Conditioned { get; set; }
        public decimal? StrainAtBreak_Conditioned_Mm_Min { get; set; }

        // Flexural
        public decimal? FlexuralModulus_DAM { get; set; }
        public decimal? FlexuralModulus_Conditioned { get; set; }
        public decimal? FlexuralModulus_Conditioned_Mm_Min { get; set; }

        public decimal? FlexuralStrength_DAM { get; set; }
        public decimal? FlexuralStrength_Conditioned { get; set; }
        public decimal? FlexuralStrength_Conditioned_Mm_Min { get; set; }

        public decimal? FlexuralStrainBreak_DAM { get; set; }
        public decimal? FlexuralStrainBreak_Conditioned { get; set; }

        // Charpy Impact
        public decimal? CharpyImpact_DAM { get; set; }
        public decimal? CharpyImpact_Conditioned { get; set; }
        public decimal? CharpyNotchedImpact23 { get; set; }
        public decimal? CharpyNotchedImpactMinus30 { get; set; }

        // Izod Notched Impact
        public decimal? IzodNotchedImpact_DAM { get; set; }
        public decimal? IzodNotchedImpact_Conditioned { get; set; }

        // Shore D Hardness
        public decimal? ShoreDHardness_DAM { get; set; }
        public decimal? ShoreDHardness_Conditioned { get; set; }

        public bool IsDelete { get; set; } = false;

        // Navigation property
        public Test Test { get; set; }
    }

}

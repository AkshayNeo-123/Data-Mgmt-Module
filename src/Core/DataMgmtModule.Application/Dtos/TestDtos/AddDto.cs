using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMgmtModule.Application.Dtos.TestDtos
{
    public class AddDto
    {
        public int RecipeNumber { get; set; }
        public string Comment { get; set; }
        public bool IsPublish { get; set; }

    }

    public class MechanicalPropertyDto
    {
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

        public decimal? FlexuralModulus_DAM { get; set; }
        public decimal? FlexuralModulus_Conditioned { get; set; }
        public decimal? FlexuralModulus_Conditioned_Mm_Min { get; set; }

        public decimal? FlexuralStrength_DAM { get; set; }
        public decimal? FlexuralStrength_Conditioned { get; set; }
        public decimal? FlexuralStrength_Conditioned_Mm_Min { get; set; }

        public decimal? FlexuralStrainBreak_DAM { get; set; }
        public decimal? FlexuralStrainBreak_Conditioned { get; set; }

        public decimal? CharpyImpact_DAM { get; set; }
        public decimal? CharpyImpact_Conditioned { get; set; }
        public decimal? CharpyNotchedImpact23 { get; set; }
        public decimal? CharpyNotchedImpactMinus30 { get; set; }

        public decimal? IzodNotchedImpact_DAM { get; set; }
        public decimal? IzodNotchedImpact_Conditioned { get; set; }

        public decimal? ShoreDHardness_DAM { get; set; }
        public decimal? ShoreDHardness_Conditioned { get; set; }

    }

    public class TemperaturePropertyDto
    {
        public decimal? TempHdtA { get; set; }
        public decimal? TempHdtB { get; set; }
        public decimal? MeltingTemp { get; set; }
        public decimal? CoefficientsParallel { get; set; }
        public decimal? CoefficientsTransverse { get; set; }
    }

    public class FlammabilityPropertyDto
    {
        public int? BurningRateWallThickness { get; set; }
        public int? GWFI { get; set; }
        public int? GWFT { get; set; }
        public int? BurningRateThickness1 { get; set; }
        public int? BurningRateThickness2 { get; set; }
    }

    public class GeneralPropertyDto
    {
        public int? Density { get; set; }

        public int? HumidityAbsorption { get; set; }

        public int? MoldingShrinkageFlow { get; set; }

        public int? MoldingShrinkageTransverse { get; set; }

        public int? MFR { get; set; }

        public int? MVR { get; set; }
    }

    public class ElectricalPropertyDto
    {
        public int? VolumeResistivity1 { get; set; }
        public int? VolumeResistivity2 { get; set; }
        public int? SurfaceResistivity { get; set; }
        public int? ComparativeTracking { get; set; }
    }

    public class PropertiesDto
    {
        public bool Sustainable { get; set; }
        public bool FlameRetardant { get; set; }
        public bool HeatStabilized130 { get; set; }
        public bool HeatStabilized160 { get; set; }
        public bool HeatStabilized230 { get; set; }
        public bool HydrolysisStabilized { get; set; }
        public bool LaserTransparent { get; set; }
        public bool LaserMarkable { get; set; }
        public bool LowWarpage { get; set; }
        public bool ReducedDensity { get; set; }
        public bool ReducedMoisture { get; set; }
        public bool ElectricallyNeutral { get; set; }
        public bool UVStabilized { get; set; }
        public bool SurfaceModified { get; set; }
        public bool AdhesionModified { get; set; }
        public bool TribologicalModified { get; set; }
        public bool EasyFlow { get; set; }
        public bool Nucleated { get; set; }
        public bool ProcessImproved { get; set; }
        public bool FluidInjection { get; set; }
        public bool RecycledContent { get; set; }
        public bool AdditiveManufacturing { get; set; }
    }

   

}

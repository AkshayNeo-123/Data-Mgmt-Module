//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using DataMgmtModule.Application.Dtos.TestDtos;
//using DataMgmtModule.Application.Interface.Persistence;
//using MediatR;

//namespace DataMgmtModule.Application.Feactures.TestFeactures.Query.GetTestById
//{
//    public class GetTestByIdQueryHandler : IRequestHandler<GetTestByIdQuery, DetailedTestDto>
//    {
//        private readonly ITestRepository _testRepository;

//        public GetTestByIdQueryHandler(ITestRepository testRepository)
//        {
//            _testRepository = testRepository;
//        }

//        public async Task<DetailedTestDto> Handle(GetTestByIdQuery request, CancellationToken cancellationToken)
//        {
//            var test = await _testRepository.GetTestByIdWithProperties(request.Id);

//            if (test == null) return null;

//            return new DetailedTestDto
//            {
//                TestId = test.Id,
//                RecipeNumber = test.RecipeNumber,
//                Comment = test.Comment,
//                IsPublish = test.IsPublish,
//                RecipeName = test.Recipe?.ProductName,
//                MainPolymerName = test.Recipe?.MainPolymer?.Name,
//                MechanicalProperty = test.MechanicalProperty != null ? new MechanicalPropertyDto
//                {
//                    TensileModulus_DAM = test.MechanicalProperty.TensileModulus_DAM,
//                    TensileModulus_Conditioned = test.MechanicalProperty.TensileModulus_Conditioned,
//                    TensileModulus_Conditioned_Mm_Min = test.MechanicalProperty.TensileModulus_Conditioned_Mm_Min,
//                    StressAtYield_DAM = test.MechanicalProperty.StressAtYield_DAM,
//                    StressAtYield_Conditioned = test.MechanicalProperty.StressAtYield_Conditioned,
//                    StressAtYield_Conditioned_Mm_Min = test.MechanicalProperty.StressAtYield_Conditioned_Mm_Min,
//                    StrainAtYield_DAM = test.MechanicalProperty.StrainAtYield_DAM,
//                    StrainAtYield_Conditioned = test.MechanicalProperty.StrainAtYield_Conditioned,
//                    StrainAtYield_Conditioned_Mm_Min = test.MechanicalProperty.StrainAtYield_Conditioned_Mm_Min,
//                    StrainAtBreak_DAM = test.MechanicalProperty.StrainAtBreak_DAM,
//                    StrainAtBreak_Conditioned = test.MechanicalProperty.StrainAtBreak_Conditioned,
//                    StrainAtBreak_Conditioned_Mm_Min = test.MechanicalProperty.StrainAtBreak_Conditioned_Mm_Min,
//                    FlexuralModulus_DAM = test.MechanicalProperty.FlexuralModulus_DAM,
//                    FlexuralModulus_Conditioned = test.MechanicalProperty.FlexuralModulus_Conditioned,
//                    FlexuralModulus_Conditioned_Mm_Min = test.MechanicalProperty.FlexuralModulus_Conditioned_Mm_Min,
//                    FlexuralStrength_DAM = test.MechanicalProperty.FlexuralStrength_DAM,
//                    FlexuralStrength_Conditioned = test.MechanicalProperty.FlexuralStrength_Conditioned,
//                    FlexuralStrength_Conditioned_Mm_Min = test.MechanicalProperty.FlexuralStrength_Conditioned_Mm_Min,
//                    FlexuralStrainBreak_DAM = test.MechanicalProperty.FlexuralStrainBreak_DAM,
//                    FlexuralStrainBreak_Conditioned = test.MechanicalProperty.FlexuralStrainBreak_Conditioned,
//                    CharpyImpact_DAM = test.MechanicalProperty.CharpyImpact_DAM,
//                    CharpyImpact_Conditioned = test.MechanicalProperty.CharpyImpact_Conditioned,
//                    CharpyNotchedImpact23 = test.MechanicalProperty.CharpyNotchedImpact23,
//                    CharpyNotchedImpactMinus30 = test.MechanicalProperty.CharpyNotchedImpactMinus30,
//                    IzodNotchedImpact_DAM = test.MechanicalProperty.IzodNotchedImpact_DAM,
//                    IzodNotchedImpact_Conditioned = test.MechanicalProperty.IzodNotchedImpact_Conditioned,
//                    ShoreDHardness_DAM = test.MechanicalProperty.ShoreDHardness_DAM,
//                    ShoreDHardness_Conditioned = test.MechanicalProperty.ShoreDHardness_Conditioned
//                } : null,
//                TemperatureProperty = test.TemperatureProperty != null ? new TemperaturePropertyDto
//                {
//                    TempHdtA = test.TemperatureProperty.TempHdtA,
//                    TempHdtB = test.TemperatureProperty.TempHdtB,
//                    MeltingTemp = test.TemperatureProperty.MeltingTemp,
//                    CoefficientsParallel = test.TemperatureProperty.CoefficientsParallel,
//                    CoefficientsTransverse = test.TemperatureProperty.CoefficientsTransverse
//                } : null,
//                FlammabilityProperty = test.FlammabilityProperty != null ? new FlammabilityPropertyDto
//                {
//                    BurningRateWallThickness = test.FlammabilityProperty.BurningRateWallThickness,
//                    Gwfi = test.FlammabilityProperty.GWFI,
//                    Gwft = test.FlammabilityProperty.GWFT,
//                    BurningRateThickness1 = test.FlammabilityProperty.BurningRateThickness1,
//                    BurningRateThickness2 = test.FlammabilityProperty.BurningRateThickness2
//                } : null,
//                GeneralProperty = test.GeneralProperty != null ? new GeneralPropertyDto
//                {
//                    Density = test.GeneralProperty.Density,
//                    HumidityAbsorption = test.GeneralProperty.HumidityAbsorption,
//                    MoldingShrinkageFlow = test.GeneralProperty.MoldingShrinkageFlow,
//                    MoldingShrinkageTransverse = test.GeneralProperty.MoldingShrinkageTransverse,
//                    Mfr = test.GeneralProperty.MFR,
//                    Mvr = test.GeneralProperty.MVR
//                } : null,
//                ElectricalProperty = test.ElectricalProperty != null ? new ElectricalPropertyDto
//                {
//                    VolumeResistivity1 = test.ElectricalProperty.VolumeResistivity1,
//                    VolumeResistivity2 = test.ElectricalProperty.VolumeResistivity2,
//                    SurfaceResistivity = test.ElectricalProperty.SurfaceResistivity,
//                    ComparativeTracking = test.ElectricalProperty.ComparativeTracking
//                } : null,
//                Properties = test.Properties != null ? new PropertiesDto
//                {
//                    Sustainable = test.Properties.Sustainable,
//                    FlameRetardant = test.Properties.FlameRetardant,
//                    HeatStabilized130 = test.Properties.HeatStabilized130,
//                    HeatStabilized160 = test.Properties.HeatStabilized160,
//                    HeatStabilized230 = test.Properties.HeatStabilized230,
//                    HydrolysisStabilized = test.Properties.HydrolysisStabilized,
//                    LaserTransparent = test.Properties.LaserTransparent,
//                    LaserMarkable = test.Properties.LaserMarkable,
//                    LowWarpage = test.Properties.LowWarpage,
//                    ReducedDensity = test.Properties.ReducedDensity,
//                    ReducedMoisture = test.Properties.ReducedMoisture,
//                    ElectricallyNeutral = test.Properties.ElectricallyNeutral,
//                    UvStabilized = test.Properties.UVStabilized,
//                    SurfaceModified = test.Properties.SurfaceModified,
//                    AdhesionModified = test.Properties.AdhesionModified,
//                    TribologicalModified = test.Properties.TribologicalModified,
//                    EasyFlow = test.Properties.EasyFlow,
//                    Nucleated = test.Properties.Nucleated,
//                    ProcessImproved = test.Properties.ProcessImproved,
//                    FluidInjection = test.Properties.FluidInjection,
//                    RecycledContent = test.Properties.RecycledContent,
//                    AdditiveManufacturing = test.Properties.AdditiveManufacturing
//                } : null,
//                MechanicalProperty = test.MechanicalProperty != null,
//                TemperatureProperties = test.TemperatureProperty != null,
//                ElectricalProperties = test.ElectricalProperty != null,
//                GeneralProperties = test.GeneralProperty != null,
//                FlammabilityProperties = test.FlammabilityProperty != null,
//                Property = test.Properties != null
//            };
//        }
//}

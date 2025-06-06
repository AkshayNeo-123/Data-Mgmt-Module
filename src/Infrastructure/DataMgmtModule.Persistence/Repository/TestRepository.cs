
using DataMgmtModule.Application.Dtos.TestDtos;
using DataMgmtModule.Application.Exceptions;
using DataMgmtModule.Application.Features.TestFeatures.Commands.UpdateTest;
using DataMgmtModule.Application.Interface.Persistence;
using DataMgmtModule.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataMgmtModule.Persistence.Repository
{
    public class TestRepository : ITestRepository
    {
        readonly PersistenceDbContext _persistenceContext;
        public TestRepository(PersistenceDbContext persistenceContext)
        {
            _persistenceContext = persistenceContext;
        }
        public async Task<IEnumerable<Test>> GetTest()
        {
            return await _persistenceContext.Test.Include(t => t.Recipe).Include(t => t.Recipe.MainPolymer).Where(t => t.IsDelete == false).ToListAsync();
        }

        public async Task<int> AddTest(Test test)
        {
            test.IsDelete = false;
            await _persistenceContext.AddAsync(test);
            return await _persistenceContext.SaveChangesAsync();
        }

        public async Task<Test> FindByIdTest(int id)
        {
            var data = await _persistenceContext.Test.Where(t => t.Id == id).FirstOrDefaultAsync();
            return data;

        }

        //public async Task<int> UpdateTest(Test test)
        //{
        //    var testData = await FindByIdTest(test.Id);
        //    if (testData == null)
        //    {
        //        throw new NotFoundException($"Test Id={test.Id} is not Found!!");
        //    }
        //    testData.RecipeNumber = test.RecipeNumber;
        //    testData.Comment = test.Comment;
        //    testData.IsPublish = test.IsPublish;

        //    return await _persistenceContext.SaveChangesAsync();
        //}

        public async Task<int> UpdateTestWithProperties(UpdateTestCommand request)
        {
            var existingTest = await _persistenceContext.Test
                .Include(t => t.TemperatureProperty)
                .Include(t => t.FlammabilityProperty)
                .Include(t => t.MechanicalProperty)
                .Include(t => t.GeneralProperty)
                .Include(t => t.ElectricalProperty)
                .Include(t => t.Properties)
                .FirstOrDefaultAsync(t => t.Id == request.TestId);

            if (existingTest == null) return 0;

            // Test entity
            existingTest.RecipeNumber = request.Test.RecipeNumber;
            existingTest.Comment = request.Test.Comment;
            existingTest.IsPublish = request.Test.IsPublish;

            // TemperatureProperty
            existingTest.TemperatureProperty.TempHdtA = request.TemperatureProperty.TempHdtA;
            existingTest.TemperatureProperty.TempHdtB = request.TemperatureProperty.TempHdtB;
            existingTest.TemperatureProperty.MeltingTemp = request.TemperatureProperty.MeltingTemp;
            existingTest.TemperatureProperty.CoefficientsParallel = request.TemperatureProperty.CoefficientsParallel;
            existingTest.TemperatureProperty.CoefficientsTransverse = request.TemperatureProperty.CoefficientsTransverse;

            // FlammabilityProperty
            existingTest.FlammabilityProperty.BurningRateWallThickness = request.FlammabilityProperty.BurningRateWallThickness;
            existingTest.FlammabilityProperty.GWFI = request.FlammabilityProperty.GWFI;
            existingTest.FlammabilityProperty.GWFT = request.FlammabilityProperty.GWFT;
            existingTest.FlammabilityProperty.BurningRateThickness1 = request.FlammabilityProperty.BurningRateThickness1;
            existingTest.FlammabilityProperty.BurningRateThickness2 = request.FlammabilityProperty.BurningRateThickness2;

            // MechanicalProperty
            existingTest.MechanicalProperty.TensileModulus_DAM = request.MechanicalProperty.TensileModulus_DAM;
            existingTest.MechanicalProperty.TensileModulus_Conditioned = request.MechanicalProperty.TensileModulus_Conditioned;
            existingTest.MechanicalProperty.TensileModulus_Conditioned_Mm_Min = request.MechanicalProperty.TensileModulus_Conditioned_Mm_Min;

            existingTest.MechanicalProperty.StressAtYield_DAM = request.MechanicalProperty.StressAtYield_DAM;
            existingTest.MechanicalProperty.StressAtYield_Conditioned = request.MechanicalProperty.StressAtYield_Conditioned;
            existingTest.MechanicalProperty.StressAtYield_Conditioned_Mm_Min = request.MechanicalProperty.StressAtYield_Conditioned_Mm_Min;

            existingTest.MechanicalProperty.StrainAtYield_DAM = request.MechanicalProperty.StrainAtYield_DAM;
            existingTest.MechanicalProperty.StrainAtYield_Conditioned = request.MechanicalProperty.StrainAtYield_Conditioned;
            existingTest.MechanicalProperty.StrainAtYield_Conditioned_Mm_Min = request.MechanicalProperty.StrainAtYield_Conditioned_Mm_Min;

            existingTest.MechanicalProperty.StrainAtBreak_DAM = request.MechanicalProperty.StrainAtBreak_DAM;
            existingTest.MechanicalProperty.StrainAtBreak_Conditioned = request.MechanicalProperty.StrainAtBreak_Conditioned;
            existingTest.MechanicalProperty.StrainAtBreak_Conditioned_Mm_Min = request.MechanicalProperty.StrainAtBreak_Conditioned_Mm_Min;

            existingTest.MechanicalProperty.FlexuralModulus_DAM = request.MechanicalProperty.FlexuralModulus_DAM;
            existingTest.MechanicalProperty.FlexuralModulus_Conditioned = request.MechanicalProperty.FlexuralModulus_Conditioned;
            existingTest.MechanicalProperty.FlexuralModulus_Conditioned_Mm_Min = request.MechanicalProperty.FlexuralModulus_Conditioned_Mm_Min;

            existingTest.MechanicalProperty.FlexuralStrength_DAM = request.MechanicalProperty.FlexuralStrength_DAM;
            existingTest.MechanicalProperty.FlexuralStrength_Conditioned = request.MechanicalProperty.FlexuralStrength_Conditioned;
            existingTest.MechanicalProperty.FlexuralStrength_Conditioned_Mm_Min = request.MechanicalProperty.FlexuralStrength_Conditioned_Mm_Min;

            existingTest.MechanicalProperty.FlexuralStrainBreak_DAM = request.MechanicalProperty.FlexuralStrainBreak_DAM;
            existingTest.MechanicalProperty.FlexuralStrainBreak_Conditioned = request.MechanicalProperty.FlexuralStrainBreak_Conditioned;

            existingTest.MechanicalProperty.CharpyImpact_DAM = request.MechanicalProperty.CharpyImpact_DAM;
            existingTest.MechanicalProperty.CharpyImpact_Conditioned = request.MechanicalProperty.CharpyImpact_Conditioned;
            existingTest.MechanicalProperty.CharpyNotchedImpact23 = request.MechanicalProperty.CharpyNotchedImpact23;
            existingTest.MechanicalProperty.CharpyNotchedImpactMinus30 = request.MechanicalProperty.CharpyNotchedImpactMinus30;

            existingTest.MechanicalProperty.IzodNotchedImpact_DAM = request.MechanicalProperty.IzodNotchedImpact_DAM;
            existingTest.MechanicalProperty.IzodNotchedImpact_Conditioned = request.MechanicalProperty.IzodNotchedImpact_Conditioned;

            existingTest.MechanicalProperty.ShoreDHardness_DAM = request.MechanicalProperty.ShoreDHardness_DAM;
            existingTest.MechanicalProperty.ShoreDHardness_Conditioned = request.MechanicalProperty.ShoreDHardness_Conditioned;

            // GeneralProperty
            existingTest.GeneralProperty.Density = request.GeneralProperty.Density;
            existingTest.GeneralProperty.HumidityAbsorption = request.GeneralProperty.HumidityAbsorption;
            existingTest.GeneralProperty.MoldingShrinkageFlow = request.GeneralProperty.MoldingShrinkageFlow;
            existingTest.GeneralProperty.MoldingShrinkageTransverse = request.GeneralProperty.MoldingShrinkageTransverse;
            existingTest.GeneralProperty.MFR = request.GeneralProperty.MFR;
            existingTest.GeneralProperty.MVR = request.GeneralProperty.MVR;

            // ElectricalProperty
            existingTest.ElectricalProperty.VolumeResistivity1 = request.ElectricalProperty.VolumeResistivity1;
            existingTest.ElectricalProperty.VolumeResistivity2 = request.ElectricalProperty.VolumeResistivity2;
            existingTest.ElectricalProperty.SurfaceResistivity = request.ElectricalProperty.SurfaceResistivity;
            existingTest.ElectricalProperty.ComparativeTracking = request.ElectricalProperty.ComparativeTracking;

            // Properties
            existingTest.Properties.Sustainable = request.Properties.Sustainable;
            existingTest.Properties.FlameRetardant = request.Properties.FlameRetardant;
            existingTest.Properties.HeatStabilized130 = request.Properties.HeatStabilized130;
            existingTest.Properties.HeatStabilized160 = request.Properties.HeatStabilized160;
            existingTest.Properties.HeatStabilized230 = request.Properties.HeatStabilized230;
            existingTest.Properties.HydrolysisStabilized = request.Properties.HydrolysisStabilized;
            existingTest.Properties.LaserTransparent = request.Properties.LaserTransparent;
            existingTest.Properties.LaserMarkable = request.Properties.LaserMarkable;
            existingTest.Properties.LowWarpage = request.Properties.LowWarpage;
            existingTest.Properties.ReducedDensity = request.Properties.ReducedDensity;
            existingTest.Properties.ReducedMoisture = request.Properties.ReducedMoisture;
            existingTest.Properties.ElectricallyNeutral = request.Properties.ElectricallyNeutral;
            existingTest.Properties.UVStabilized = request.Properties.UVStabilized;
            existingTest.Properties.SurfaceModified = request.Properties.SurfaceModified;
            existingTest.Properties.AdhesionModified = request.Properties.AdhesionModified;
            existingTest.Properties.TribologicalModified = request.Properties.TribologicalModified;
            existingTest.Properties.EasyFlow = request.Properties.EasyFlow;
            existingTest.Properties.Nucleated = request.Properties.Nucleated;
            existingTest.Properties.ProcessImproved = request.Properties.ProcessImproved;
            existingTest.Properties.FluidInjection = request.Properties.FluidInjection;
            existingTest.Properties.RecycledContent = request.Properties.RecycledContent;
            existingTest.Properties.AdditiveManufacturing = request.Properties.AdditiveManufacturing;

            // Save all changes
            return await _persistenceContext.SaveChangesAsync();
        }


        public async Task<int> DeleteTest(int id, int deletedBy)
        {
            var testData = await FindByIdTest(id);
            if (testData == null)
            {
                throw new NotFoundException($"Test Id={id} is not Found!!");
            }
            var mechData = await _persistenceContext.MechanicalProperties.Where(t => t.TestId == id && t.IsDelete == false).FirstOrDefaultAsync();
            var genData = await _persistenceContext.GeneralProperties.Where(t => t.TestId == id && t.IsDelete == false).FirstOrDefaultAsync();
            var electricalData = await _persistenceContext.ElectricalProperties.Where(t => t.TestId == id && t.IsDelete == false).FirstOrDefaultAsync();
            var tempData = await _persistenceContext.TemperatureProperties.Where(t => t.TestId == id && t.IsDelete == false).FirstOrDefaultAsync();
            var proData = await _persistenceContext.Properties.Where(t => t.TestId == id && t.IsDelete == false).FirstOrDefaultAsync();
            var flamData = await _persistenceContext.FlammabilityProperties.Where(t => t.TestId == id && t.IsDelete == false).FirstOrDefaultAsync();
            if (mechData != null)
            {
                mechData.IsDelete = true;
                mechData.DeletedBy = deletedBy;
                mechData.DeletedDate = DateTime.Now;
            }
            if (flamData != null)
            {
                flamData.IsDelete = true;
                flamData.DeletedBy = deletedBy;
                flamData.DeletedDate = DateTime.Now;

            }
            if (proData != null)
            {
                proData.IsDelete = true;
                proData.DeletedBy = deletedBy;
                proData.DeletedDate = DateTime.Now;

            }
            if (tempData != null)
            {
                tempData.IsDelete = true;
                tempData.DeletedBy = deletedBy;
                tempData.DeletedDate = DateTime.Now;

            }
            if (electricalData != null)
            {
                electricalData.IsDelete = true;
                electricalData.DeletedBy = deletedBy;
                electricalData.DeletedDate = DateTime.Now;
            }
            if (genData != null)
            {
                genData.IsDelete = true;
                genData.DeletedBy = deletedBy;
                genData.DeletedDate = DateTime.Now;
            }


            testData.IsDelete = true;
            testData.DeletedBy = deletedBy;
            testData.DeletedDate = DateTime.Now;

            return await _persistenceContext.SaveChangesAsync();
        }
        public async Task<IEnumerable<Recipe>> GetRecipedataForAddTest()
        {
            var recipesNotInTests = await _persistenceContext.Recipes
            .Where(r => r.IsDelete == false && !_persistenceContext.Test
                    .Where(t => t.IsDelete == false)
                    .Select(t => t.RecipeNumber)
                    .Contains(r.ReceipeId))
            .ToListAsync();
            return recipesNotInTests;
        }

        public Task<int> DeleteTest(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<MechanicalProperty> GetMechPropertyByTest(int id)
        {
            var getMechData = await _persistenceContext.Test.FirstOrDefaultAsync(x => x.RecipeNumber ==id && x.IsDelete==false && x.IsPublish==true);
            var mech = await _persistenceContext.MechanicalProperties.FirstOrDefaultAsync(x => x.TestId == getMechData.Id);
            if (mech == null)
            {
                throw new NotFoundException($"Data with {getMechData.Id} is not found");
            }
            
            return mech;
        }
    }
}

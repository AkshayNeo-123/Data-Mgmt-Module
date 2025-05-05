using DataMgmtModule.Application.Interface.Persistence;
using DataMgmtModule.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataMgmtModule.Persistence.Repository
{
    public class MaterialsRepository : IMaterialsRepository
    {
        private readonly PersistenceDbContext _context;

        public MaterialsRepository(PersistenceDbContext context)
        {
            _context = context;
        }

        public async Task<Materials> AddMaterials(Materials material, int? userId)
        {
            material.CreatedDate = DateTime.Now;
            //material.CreatedBy = userId;
            _context.Materials.Add(material);
            await _context.SaveChangesAsync();
            return material;
        }


        public async Task<int> DeleteMaterials(int id)
        {
            var materials = await GetByIdMaterials(id);
            if (materials.IsDelete == false)
            {
                materials.IsDelete = true;
                return await _context.SaveChangesAsync();
            }
            return 0;

        }

        public async Task<IEnumerable<Materials>> GetAllMaterials()
        {
            var materials = await _context.Materials
                .Where(x => x.IsDelete == false)
                .Include(x => x.Additive)
                .Include(x => x.Manufacturer)
                .Include(x => x.Supplier)
                .Include(x => x.MainPolymer)
                .Include(x => x.MvrMfr)
                .Include(x => x.StorageLocation)
                .ToListAsync();

            return materials;
        }


        public async Task<Materials?> GetByIdMaterials(int id)
        {
            var material = await _context.Materials.FirstOrDefaultAsync(b => b.MaterialId == id);

            if (material == null)
                throw new Exception($"Material with ID {id} not found.");

            return material;
        }

        public async Task UpdateMaterials(Materials material, int? userId)
        {
            var existingMaterial = await _context.Materials.FindAsync(material.MaterialId);

            if (existingMaterial == null)
                throw new Exception($"Material with ID {material.MaterialId} not found.");

            
            existingMaterial.Quantity = material.Quantity;
           
            existingMaterial.Quantity = material.Quantity;
            existingMaterial.MaterialName = material.MaterialName;
            existingMaterial.Density = material.Density;
            existingMaterial.Description = material.Description;
            existingMaterial.AdditiveId = material.AdditiveId;
            //existingMaterial.MaterialsType = material.MaterialsType;
            existingMaterial.MainPolymerId = material.MainPolymerId; 
            existingMaterial.MvrMfrId = material.MvrMfrId;
            existingMaterial.TdsfilePath = material.TdsfilePath;
            existingMaterial.MsdsfilePath = material.MsdsfilePath;
            existingMaterial.StorageLocationId = material.StorageLocationId; 
            existingMaterial.TestMethod = material.TestMethod;
            existingMaterial.ManufacturerId = material.ManufacturerId;
            existingMaterial.ModifiedDate = DateTime.Now;
            existingMaterial.ModifiedBy = material.ModifiedBy;

            await _context.SaveChangesAsync();
        }

    }
}

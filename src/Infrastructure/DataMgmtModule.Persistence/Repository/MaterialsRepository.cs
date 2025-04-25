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

        public async Task<Materials> AddMaterials(Materials material , int? userId)
        {
            material.CreatedDate = DateTime.Now;
            material.CreatedBy = userId;
            _context.Materials.Add(material);
            await _context.SaveChangesAsync();
            return material;
        }

        public async Task DeleteMaterials(int id)
        {
            var material = await _context.Materials.FindAsync(id);

            //if (book == null)
            //{
            //    throw new NotFoundException($"Book with ID {id} not found.");
            //}

            _context.Materials.Remove(material);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Materials>> GetAllMaterials()
        {
            return await _context.Materials.ToListAsync();
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
            existingMaterial.Density = material.Density;
            existingMaterial.Description = material.Description;
            existingMaterial.ModifiedDate = DateTime.Now;
            existingMaterial.ModifiedBy = userId;

            await _context.SaveChangesAsync();
        }

    }
}

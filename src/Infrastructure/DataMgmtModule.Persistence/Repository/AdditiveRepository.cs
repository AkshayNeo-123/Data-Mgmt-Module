using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Application.Dtos.AdditiveDtos;
using DataMgmtModule.Application.Interface.Persistence;
using DataMgmtModule.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataMgmtModule.Persistence.Repository
{
    public class AdditiveRepository : IAdditiveRepository
    {
        private readonly PersistenceDbContext _context;

        public AdditiveRepository(PersistenceDbContext context)
        {
            _context = context;
        }

        public async Task<List<Additive>> GetAllAsync() => await _context.Additives.Where(x=>x.IsDelete==false).ToListAsync();

        public async Task<Additive?> GetByIdAsync(int id) => await _context.Additives.FindAsync(id);

        public async Task<Additive> AddAsync(CreateAdditiveDto dto, int? userId)
        {
            var additive = new Additive
            {
                IsDelete = false,
                AdditiveName = dto.AdditiveName,
                CreatedBy = userId,
                CreatedDate = DateTime.Now
            };
            _context.Additives.Add(additive);
            await _context.SaveChangesAsync();
            return additive;
        }

        public async Task<bool> UpdateAsync(int id, UpdateAdditiveDto dto,int? userId)
        {
            var existing = await _context.Additives.FindAsync(id);
            if (existing == null) return false;

            existing.AdditiveName = dto.AdditiveName;
            existing.ModifiedBy = userId;
            existing.ModifiedDate = DateTime.Now;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var additive = await _context.Additives.FindAsync(id);
            //if (additive == null) return false;

            //_context.Additives.Remove(additive);
            if (additive.IsDelete == false)
            {
                additive.IsDelete = true;
                await _context.SaveChangesAsync();

            }
            return true;
        }
    }
}

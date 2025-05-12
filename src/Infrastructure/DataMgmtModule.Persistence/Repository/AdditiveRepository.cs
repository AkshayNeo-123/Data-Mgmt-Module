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

        public async Task<Additive> AddAsync(Additive dto, int? userId)
        {

            dto.IsDelete = false;
            //dto.AdditiveName = dto.AdditiveName,
            //CreatedBy = userId,
            dto.CreatedDate = DateTime.Now;
            
            _context.Additives.Add(dto);
            await _context.SaveChangesAsync();
            return dto;
        }

        public async Task<bool> UpdateAsync(int id, Additive dto,int? userId)
       {
            var existing = await _context.Additives.FindAsync(id);
            if (existing == null) return false;
            //existing.CreatedDate=DateTime.Now;
            //existing.CreatedBy = dto.CreatedBy;

            existing.AdditiveName = dto.AdditiveName;
            existing.ModifiedBy = dto.ModifiedBy;
            existing.ModifiedDate = DateTime.Now;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id,int deletedBy)
        {
            var additive = await _context.Additives.FindAsync(id);
            //if (additive == null) return false;

            //_context.Additives.Remove(additive);
            if (additive.IsDelete == false)
            {
                additive.DeletedBy = deletedBy;
                additive.DeletedDate = DateTime.Now;
                additive.IsDelete = true;
                await _context.SaveChangesAsync();

            }
            return true;
        }
    }
}

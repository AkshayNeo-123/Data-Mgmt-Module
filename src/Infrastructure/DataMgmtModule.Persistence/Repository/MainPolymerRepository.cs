using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Application.Dtos.MainPolymerDtos;
using DataMgmtModule.Application.Interface.Persistence;
using DataMgmtModule.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataMgmtModule.Persistence.Repository
{
    public class MainPolymerRepository : IMainPolymerRepository
    {
        private readonly PersistenceDbContext _context;
        public MainPolymerRepository(PersistenceDbContext context)
        {
            _context = context;
        }

        public async Task<List<MainPolymer>> GetAllAsync()
        {
            try
            {

               return await _context.MainPolymers.ToListAsync();
            }
            catch (Exception Ex)
            {
                throw Ex;
               
            }
        }

        public async Task<MainPolymer?> GetByIdAsync(int id) => await _context.MainPolymers.FindAsync(id);

        public async Task<MainPolymer> AddAsync(CreateMainPolymerDto dto, int? userId)
        {
            var polymer = new MainPolymer
            {
                PolymerName = dto.PolymerName,
                CreatedBy = userId,
                CreatedDate = DateTime.Now
            };
            _context.MainPolymers.Add(polymer);
            await _context.SaveChangesAsync();
            return polymer;
        }

        public async Task<bool> UpdateAsync(int id, UpdateMainPolymerDto dto,int? userId)
        {
            var existing = await _context.MainPolymers.FindAsync(id);
            if (existing == null) return false;

            existing.PolymerName = dto.PolymerName;
            existing.ModifiedBy = userId;
            existing.ModifiedDate = DateTime.Now;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var polymer = await _context.MainPolymers.FindAsync(id);
            if (polymer == null) return false;

            _context.MainPolymers.Remove(polymer);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

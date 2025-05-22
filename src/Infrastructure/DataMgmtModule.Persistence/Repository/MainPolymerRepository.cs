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

        public async Task<MainPolymer> AddAsync(MainPolymer dto, int? userId)
        {

            //IsDelete=false,
            //PolymerName = dto.PolymerName,
            //CreatedBy = userId,
            //CreatedDate = DateTime.Now
            //};
            dto.IsDelete = false;
            _context.MainPolymers.Add(dto);
            await _context.SaveChangesAsync();
            return dto;
        }

        public async Task<bool> UpdateAsync(int id, MainPolymer dto,int? userId)
        {
            var existing = await _context.MainPolymers.FindAsync(id);
            if (existing == null) return false;

            existing.PolymerName = dto.PolymerName;
            existing.ModifiedBy = dto.ModifiedBy;
            existing.ModifiedDate = DateTime.Now;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id,int deletedBy)
        {
            var polymer = await _context.MainPolymers.FindAsync(id);
            //if (polymer == null) return false;

            //_context.MainPolymers.Remove(polymer);

            if (polymer.IsDelete == false)
            {
                polymer.IsDelete = true;
                polymer.DeletedBy = deletedBy;
                polymer.DeletedDate = DateTime.Now;
                await _context.SaveChangesAsync();

            }
            return true;
        }
    }
}

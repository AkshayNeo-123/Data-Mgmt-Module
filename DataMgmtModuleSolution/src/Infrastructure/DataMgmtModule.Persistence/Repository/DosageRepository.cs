using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Application.Exceptions;
using DataMgmtModule.Application.Interface.Persistence;
using DataMgmtModule.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DataMgmtModule.Persistence.Repository
{
    public class DosageRepository : IDosageRepository
    {
        private readonly PersistenceDbContext _persistenceDbContext;

        public DosageRepository(PersistenceDbContext persistenceDbContext)
        {
            _persistenceDbContext = persistenceDbContext;
        }
        public async Task<int> AddDosageAsync(int compoundingId, Dosage dosage)
        {

            var data = await _persistenceDbContext.CompoundingData.FindAsync(compoundingId);

            if (data == null)
            {
                throw new Exception("No CompoundingData found!");
            }

            dosage.CompoundingId = compoundingId;   //1

            await _persistenceDbContext.Dosages.AddAsync(dosage);
            var saved = await _persistenceDbContext.SaveChangesAsync();

            if (saved <= 0)
                return 0;

            return 1;
        }

        //public async Task<Dosage> DeleteDosageAsync(int id)
        //{
        //    var getDosage =await _persistenceDbContext.Dosage.FindAsync(id);
        //     _persistenceDbContext.Remove(getDosage);
        //    await _persistenceDbContext.SaveChangesAsync();
        //    return getDosage;
        //}

        public Task<Dosage> GetDosageAsync(int id)
        {
            var getDosage = _persistenceDbContext.Dosages.FirstOrDefaultAsync();
            if (getDosage == null)
            {
                throw new Exception("Dosage data Not Found!!");
            }
            return getDosage;
        }

        public async Task<int> UpdateDosageAsync(int compoundId, Dosage dosage)
        {
            var compoundingData = await _persistenceDbContext.Dosages.Where(x => x.CompoundingId == compoundId).FirstOrDefaultAsync();

            if (compoundingData == null)
            {
                throw new NotFoundException("No CompoundingData found!");
            }

            compoundingData.SpeedSideFeeder1 = dosage.SpeedSideFeeder1;
            compoundingData.SpeedSideFeeder2 = dosage.SpeedSideFeeder2;
            compoundingData.UploadScrewconfig = dosage.UploadScrewconfig;
            compoundingData.TemperatureProfile = dosage.TemperatureProfile;
            compoundingData.ScrewConfig = dosage.ScrewConfig;
            compoundingData.ScrewSpeed = dosage.ScrewSpeed;
            compoundingData.Torque = dosage.Torque;
            compoundingData.Pressure = dosage.Pressure;
            compoundingData.TotalOutput = dosage.TotalOutput;
            compoundingData.Granulator = dosage.Granulator;
            compoundingData.BulkDensity = dosage.BulkDensity;
            compoundingData.CoolingSection = dosage.CoolingSection;
            compoundingData.TemperatureWaterBath = dosage.TemperatureWaterBath;
            compoundingData.Notes = dosage.Notes;
            compoundingData.MeltPump = dosage.MeltPump;
            compoundingData.NozzlePlate = dosage.NozzlePlate;
            compoundingData.Premix = dosage.Premix;
            compoundingData.UnderwaterPelletizer = dosage.UnderwaterPelletizer;

            //_persistenceDbContext.Dosage.Update(dosage);
            var saved = await _persistenceDbContext.SaveChangesAsync();

            if (saved <= 0)
                return 0;

            return 1;
        }
    }
}

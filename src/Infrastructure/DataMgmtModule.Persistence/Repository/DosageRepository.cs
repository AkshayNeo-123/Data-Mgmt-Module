using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Application.Dtos.Dosage;
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
        public async Task<int> AddDosageAsync(int compoundingId, Dosage dosage, int? userId)
        {

            var data = await _persistenceDbContext.CompoundingData.FindAsync(compoundingId);

            if (data == null)
            {
                throw new Exception("No CompoundingData found!");
            }

            dosage.CompoundingId = compoundingId;   //1
            //dosage.CreatedBy = userId;
            dosage.CreatedDate = DateTime.Now;

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
            var getDosage = _persistenceDbContext.Dosages.FirstOrDefaultAsync(x=>x.DosageId==id);
            if (getDosage == null)
            {
                throw new Exception("Dosage data Not Found!!");
            }
            return getDosage;
        }
        public async Task<Dosage> getDosagebyCompoundingId(int id)
        {
            var getDosage = await _persistenceDbContext.Dosages
                .Where(x => x.CompoundingId == id)
                .FirstOrDefaultAsync();

            if (getDosage == null)
            {
                throw new Exception("Dosage data Not Found!!");
            }

            return getDosage;
        }


        public async Task<int> UpdateDosageAsync(int compoundId, Dosage dosage, int? userId)
        {
            var compoundingData = await _persistenceDbContext.Dosages.Where(x => x.CompoundingId == compoundId).FirstOrDefaultAsync();

            if (compoundingData == null)
            {
                throw new NotFoundException("No CompoundingData found!");
            }

            compoundingData.SpeedSideFeeder1 = dosage.SpeedSideFeeder1;
            compoundingData.SpeedSideFeeder2 = dosage.SpeedSideFeeder2;
            compoundingData.UploadScrewconfig = dosage.UploadScrewconfig;
            compoundingData.Temp1 = dosage.Temp1;
            compoundingData.Temp2 = dosage.Temp2;
            compoundingData.Temp3 = dosage.Temp3;
            compoundingData.Temp4 = dosage.Temp4;
            compoundingData.Temp5 = dosage.Temp5;
            compoundingData.Temp6 = dosage.Temp6;
            compoundingData.Temp7 = dosage.Temp7;
            compoundingData.Temp8 = dosage.Temp8;
            compoundingData.Temp9 = dosage.Temp9;
            compoundingData.Temp10 = dosage.Temp10;
            compoundingData.Temp11 = dosage.Temp11;
            compoundingData.Temp12 = dosage.Temp12;
            compoundingData.ScrewConfigStadard = dosage.ScrewConfigStadard;
            compoundingData.ScrewConfigModified = dosage.ScrewConfigModified;
            compoundingData.DeggassingStadard = dosage.DeggassingStadard;
            compoundingData.DeggassingVaccuum = dosage.DeggassingVaccuum;
            compoundingData.DeggassingNone = dosage.DeggassingNone;
            compoundingData.DeggassingFET = dosage.DeggassingFET;
            compoundingData.PremixNote = dosage.PremixNote;
            compoundingData.TemperatureWaterBath1 = dosage.TemperatureWaterBath1;
            compoundingData.TemperatureWaterBath2 = dosage.TemperatureWaterBath2;
            compoundingData.TemperatureWaterBath3 = dosage.TemperatureWaterBath3;
            compoundingData.ScrewSpeed = dosage.ScrewSpeed;
            compoundingData.Torque = dosage.Torque;
            compoundingData.Pressure = dosage.Pressure;
            compoundingData.TotalOutput = dosage.TotalOutput;
            compoundingData.Granulator = dosage.Granulator;
            compoundingData.BulkDensity = dosage.BulkDensity;
            compoundingData.CoolingSection = dosage.CoolingSection;
            compoundingData.Notes = dosage.Notes;
            compoundingData.MeltPump = dosage.MeltPump;
            compoundingData.NozzlePlate = dosage.NozzlePlate;
            compoundingData.Premix = dosage.Premix;
            compoundingData.UnderwaterPelletizer = dosage.UnderwaterPelletizer;
            compoundingData.ModifiedBy = dosage.ModifiedBy;
            compoundingData.ModifiedDate = DateTime.Now;
            var saved = await _persistenceDbContext.SaveChangesAsync();

            if (saved <= 0)
                return 0;

            return 1;
        }
    }
}

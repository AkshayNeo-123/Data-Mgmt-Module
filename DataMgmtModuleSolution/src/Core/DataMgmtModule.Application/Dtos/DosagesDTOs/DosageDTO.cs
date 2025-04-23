using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Domain.Enum.DosageENUM;

namespace DataMgmtModule.Application.Dtos.Dosage
{
    public class DosageDTO
    {
        //public int CompoundingId { get; set; }

        public int SpeedSideFeeder1 { get; set; }
        public int SpeedSideFeeder2 { get; set; }
        public string Upload_Screwconfig { get; set; }
        public int TemperatureProfile { get; set; }
        public ScrewConfig ScrewConfig { get; set; }
        public Deggassing Deggassing { get; set; }
        public int screwSpeed { get; set; }
        public int Torque { get; set; }
        public int Pressure { get; set; }
        public int TotalOutput { get; set; }
        public int Granulator { get; set; }
        public int BulkDensity { get; set; }
        public int CoolingSection { get; set; }
        public decimal TemperatureWaterBath { get; set; }
        public string Notes { get; set; }
        public int MeltPump { get; set; }
        public int NozzlePlate { get; set; }
        public int Premix { get; set; }
        public int UnderwaterPelletizer { get; set; }



    }
}

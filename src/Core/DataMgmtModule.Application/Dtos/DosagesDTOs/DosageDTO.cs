using System;
using DataMgmtModule.Domain.Enum.DosageENUM;

namespace DataMgmtModule.Application.Dtos.Dosage
{
    public class DosageDTO
    {
        public int? SpeedSideFeeder1 { get; set; }
        public int? SpeedSideFeeder2 { get; set; }

        public string? Upload_Screwconfig { get; set; }

        
        public int? screwSpeed { get; set; }
        public int? Torque { get; set; }
        public int? Pressure { get; set; }
        public int? TotalOutput { get; set; }
        public int? Granulator { get; set; }
        public int? BulkDensity { get; set; }
        public int? CoolingSection { get; set; }


        public string? Notes { get; set; }
        public int? MeltPump { get; set; }
        public int? NozzlePlate { get; set; }
        public bool? Premix { get; set; }
        public int? UnderwaterPelletizer { get; set; }

        // Newly added temperature zones
        public decimal? Temp1 { get; set; }
        public decimal? Temp2 { get; set; }
        public decimal? Temp3 { get; set; }
        public decimal? Temp4 { get; set; }
        public decimal? Temp5 { get; set; }
        public decimal? Temp6 { get; set; }
        public decimal? Temp7 { get; set; }
        public decimal? Temp8 { get; set; }
        public decimal? Temp9 { get; set; }
        public decimal? Temp10 { get; set; }
        public decimal? Temp11 { get; set; }
        public decimal? Temp12 { get; set; }

        // ScrewConfig and Deggassing bit flags
        public bool? ScrewConfigStadard { get; set; }
        public bool? ScrewConfigModified { get; set; }

        public bool? DeggassingStadard { get; set; }
        public bool? DeggassingVaccuum { get; set; }
        public bool? DeggassingNone { get; set; }
        public bool? DeggassingFET { get; set; }

        public string? PremixNote { get; set; }

        public decimal? TemperatureWaterBath1 { get; set; }
        public decimal? TemperatureWaterBath2 { get; set; }
        public decimal? TemperatureWaterBath3 { get; set; }

        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}

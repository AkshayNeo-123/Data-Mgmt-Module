using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DataMgmtModule.Domain.Entities
{
    public class Properties : CommonTest
    {
        [Key]
        public int Id { get; set; }
        public int TestId { get; set; }
        public bool Sustainable { get; set; } = false;
        public bool FlameRetardant { get; set; } = false;
        public bool HeatStabilized130 { get; set; } = false;
        public bool HeatStabilized160 { get; set; } = false;
        public bool HeatStabilized230 { get; set; } = false;
        public bool HydrolysisStabilized { get; set; } = false;
        public bool LaserTransparent { get; set; } = false;
        public bool LaserMarkable { get; set; } = false;
        public bool LowWarpage { get; set; } = false;
        public bool ReducedDensity { get; set; } = false;
        public bool ReducedMoisture { get; set; } = false;
        public bool ElectricallyNeutral { get; set; } = false;
        public bool UVStabilized { get; set; } = false;
        public bool SurfaceModified { get; set; } = false;
        public bool AdhesionModified { get; set; } = false;
        public bool TribologicalModified { get; set; } = false;
        public bool EasyFlow { get; set; } = false;
        public bool Nucleated { get; set; } = false;
        public bool ProcessImproved { get; set; } = false;
        public bool FluidInjection { get; set; } = false;
        public bool RecycledContent { get; set; } = false;
        public bool AdditiveManufacturing { get; set; } = false;
        public bool IsDelete { get; set; } = false;

        public Test Test { get; set; }


    }
}

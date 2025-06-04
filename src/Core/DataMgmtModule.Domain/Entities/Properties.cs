using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataMgmtModule.Domain.Entities
{
    public class Properties : CommonTest
    {
        [Key]
        public int Id { get; set; }
        public int TestId { get; set; }

        public bool? Sustainable { get; set; }
        public bool? FlameRetardant { get; set; }
        public bool? HeatStabilized130 { get; set; }
        public bool? HeatStabilized160 { get; set; }
        public bool? HeatStabilized230 { get; set; }
        public bool? HydrolysisStabilized { get; set; }
        public bool? LaserTransparent { get; set; }
        public bool? LaserMarkable { get; set; }
        public bool? LowWarpage { get; set; }
        public bool? ReducedDensity { get; set; }
        public bool? ReducedMoisture { get; set; }
        public bool? ElectricallyNeutral { get; set; }
        public bool? UVStabilized { get; set; }
        public bool? SurfaceModified { get; set; }
        public bool? AdhesionModified { get; set; }
        public bool? TribologicalModified { get; set; }
        public bool? EasyFlow { get; set; }
        public bool? Nucleated { get; set; }
        public bool? ProcessImproved { get; set; }
        public bool? FluidInjection { get; set; }
        public bool? RecycledContent { get; set; }
        public bool? AdditiveManufacturing { get; set; }
        public bool? IsDelete { get; set; }

        public Test Test { get; set; }
    }
}

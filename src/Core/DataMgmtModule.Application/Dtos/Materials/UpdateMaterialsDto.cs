
using DataMgmtModule.Domain.Entities;

namespace DataMgmtModule.Application.Dtos.Materials
{
  public class UpdateMaterialsDto
    {
        public int? MaterialsType { get; set; }
        public string? MaterialName { get; set; }
        public int ManufacturerId { get; set; }

        public decimal? Quantity { get; set; }

        public decimal? Density { get; set; }

        public string? TestMethod { get; set; }

        public string? TdsfilePath { get; set; }

        public string? MsdsfilePath { get; set; }

        public int? StorageLocation { get; set; }

        public string? Description { get; set; }

        public int? MVR_MFR { get; set; }

        public int AdditiveId { get; set; }

        public int MainPolymerId { get; set; }
    }
}

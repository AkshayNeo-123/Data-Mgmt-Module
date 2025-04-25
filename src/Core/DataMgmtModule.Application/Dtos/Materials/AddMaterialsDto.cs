
using DataMgmtModule.Domain.Enum.MaterialsEnum;

namespace DataMgmtModule.Application.Dtos.Materials
{
   public class AddMaterialsDto
    {
        public MaterialType MaterialsType { get; set; }

        public string? Designation { get; set; }

        public int? ManufacturerId { get; set; }

        public decimal Quantity { get; set; }

        public decimal Density { get; set; }

        public string? TestMethod { get; set; }

        public string? TDSFilePath { get; set; }

        public string? MSDSFilePath { get; set; }

        public StorageLocation StorageLocation { get; set; }

        public string? Description { get; set; }

        public MvrMfrType MVR_MFR { get; set; }
    }
}



namespace DataMgmtModule.Application.Dtos.Materials
{
   public class AddMaterialsDto
    {
        //public MaterialType MaterialsType { get; set; }

        public string? MaterialName { get; set; }

        public string? Designation { get; set; }

        public int? ManufacturerId { get; set; }
        public int? SupplierId { get; set; }

        public decimal Quantity { get; set; }

        public decimal Density { get; set; }

        public string? TestMethod { get; set; }

        public string? TDSFilePath { get; set; }

        public string? MSDSFilePath { get; set; }

        public int? MvrMfrId { get; set; }

        public int? StorageLocationId { get; set; }

        public string? Description { get; set; }


        public int AdditiveId { get; set; }

        public int MainPolymerId { get; set; }
    }
}


using System.ComponentModel.DataAnnotations.Schema;
using DataMgmtModule.Domain.Entities;
using DataMgmtModule.Domain.Enum.MaterialsEnum;

namespace DataMgmtModule.Application.Dtos.Materials
{
   public class GetAllMaterialsDto
    {
        public int MaterialId { get; set; }
        public MaterialType MaterialsType { get; set; }

        public string? Designation { get; set; }

        public int? ManufacturerId { get; set; }
        [ForeignKey("ManufacturerId")]
        public virtual Contact Manufacturer { get; set; } = null!; 

        public decimal Quantity { get; set; }

        public decimal Density { get; set; }

        public string? TestMethod { get; set; }

        public string? TDSFilePath { get; set; }

        public string? MSDSFilePath { get; set; }

        public StorageLocation StorageLocation { get; set; }

        public string? Description { get; set; }

        public MvrMfrType MVR_MFR { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public int AdditiveId { get; set; }
        public virtual Additive Additive { get; set; } = null!;

        public int MainPolymerId { get; set; }
        [ForeignKey("MainPolymerId")]
        //public Vart MainPolymer MainPolymer { get; set; } = null!;public virtual Additive Additive { get; set; } = null!;

        public virtual MainPolymer MainPolymer { get; set; } = null!;
    }
}

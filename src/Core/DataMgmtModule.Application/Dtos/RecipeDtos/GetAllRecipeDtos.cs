

namespace DataMgmtModule.Application.Dtos.RecipeDtos
{
    public class GetAllRecipeDtos
    {
        public int ReceipeId { get; set; }
        //public string Project { get; set; }
        public string? ProductName { get; set; }
        //public string Comments { get; set; }
        //public int ProjectId { get; set; }
        //public DateTime CreatedDate { get; set; }
        //public int? CreatedBy { get; set; }
        //public int? ModifiedBy { get; set; }
        //public DateTime? ModifiedDate { get; set; }
        //public int? ProjectId { get; set; }
        //public int AdditiveId { get; set; }

        //public int MainPolymerId { get; set; }

        //public virtual Additive Additive { get; set; } = null!;
        //public virtual MainPolymer MainPolymer { get; set; } = null!;

        //public virtual Projects? Project { get; set; }
        public string? ProjectNumber { get; set; }


        public string? AdditiveName { get; set; }
        public string? PolymerName { get; set; }
        public string? Composition { get; set; }

    }
}

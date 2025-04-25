using DataMgmtModule.Application.Dtos.Materials;
using MediatR;

namespace DataMgmtModule.Application.Feactures.Materials.Command.UpdateMaterials
{
  public class UpdateMaterialsCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public UpdateMaterialsDto MaterialDto { get; set; } = null!;
    }
}


using MediatR;

namespace DataMgmtModule.Application.Feactures.Materials.Command.DeleteMaterials
{
  public class DeleteMaterialsCommand : IRequest<Unit>
    {
        public int MaterialId { get; set; }

        public DeleteMaterialsCommand(int id)
        {
            MaterialId = id;
        }
    }
}

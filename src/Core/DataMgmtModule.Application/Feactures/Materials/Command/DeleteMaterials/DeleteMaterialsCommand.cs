
using MediatR;

namespace DataMgmtModule.Application.Feactures.Materials.Command.DeleteMaterials
{
    public record DeleteMaterialsCommand(int id) : IRequest<int>;

}

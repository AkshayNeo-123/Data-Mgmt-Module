
using DataMgmtModule.Application.Dtos.Materials;
using MediatR;

namespace DataMgmtModule.Application.Feactures.Materials.Query.GetAllMaterials
{
    public record GetAllMaterialsQuery : IRequest<IEnumerable<GetAllMaterialsDto>> { }
}

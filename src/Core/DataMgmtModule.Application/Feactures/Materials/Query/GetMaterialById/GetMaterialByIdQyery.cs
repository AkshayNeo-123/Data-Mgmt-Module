using DataMgmtModule.Application.Dtos.Materials;
using MediatR;

namespace DataMgmtModule.Application.Feactures.Materials.Query.GetMaterialById
{
    public class GetMaterialByIdQyery : IRequest<GetAllMaterialsDto>
    {
        public int Id { get; set; }

        public GetMaterialByIdQyery(int id)
        {
            Id = id;
        }
    }
}

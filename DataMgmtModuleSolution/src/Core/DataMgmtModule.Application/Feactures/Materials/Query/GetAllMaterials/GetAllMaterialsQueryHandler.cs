
using AutoMapper;
using DataMgmtModule.Application.Dtos.Materials;
using DataMgmtModule.Application.Interface.Persistence;
using MediatR;

namespace DataMgmtModule.Application.Feactures.Materials.Query.GetAllMaterials
{
    public class GetAllMaterialsQueryHandler : IRequestHandler<GetAllMaterialsQuery, IEnumerable<GetAllMaterialsDto>>
    {
        private readonly IMaterialsRepository _materialsRepository;
        private readonly IMapper _mapper;

        public GetAllMaterialsQueryHandler(IMaterialsRepository materialsRepository, IMapper mapper)
        {
            _materialsRepository = materialsRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<GetAllMaterialsDto>> Handle(GetAllMaterialsQuery request, CancellationToken cancellationToken)
        {
            var materials = await _materialsRepository.GetAllMaterials();
            return _mapper.Map<IEnumerable<GetAllMaterialsDto>>(materials);
        }
    }
}

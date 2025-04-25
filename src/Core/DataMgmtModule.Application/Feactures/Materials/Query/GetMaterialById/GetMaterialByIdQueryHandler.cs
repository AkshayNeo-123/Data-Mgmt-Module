using AutoMapper;
using DataMgmtModule.Application.Dtos.Materials;
using DataMgmtModule.Application.Interface.Persistence;
using MediatR;

namespace DataMgmtModule.Application.Feactures.Materials.Query.GetMaterialById
{
    class GetMaterialByIdQueryHandler : IRequestHandler<GetMaterialByIdQyery, GetAllMaterialsDto>
    {
        private readonly IMaterialsRepository _materialsRepository;
        private readonly IMapper _mapper;

        public GetMaterialByIdQueryHandler(IMaterialsRepository materialRepository, IMapper mapper)
        {
            _materialsRepository = materialRepository;
            _mapper = mapper;
        }

        public async Task<GetAllMaterialsDto> Handle(GetMaterialByIdQyery request, CancellationToken cancellationToken)
        {
            var material = await _materialsRepository.GetByIdMaterials(request.Id);
            return _mapper.Map<GetAllMaterialsDto>(material);
        }
    }
}

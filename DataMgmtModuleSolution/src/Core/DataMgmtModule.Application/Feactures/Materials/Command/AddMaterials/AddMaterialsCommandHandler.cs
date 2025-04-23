using AutoMapper;
using DataMgmtModule.Application.Dtos.Materials;
using DataMgmtModule.Application.Interface.Persistence;
using MediatR;
using DomainBook = DataMgmtModule.Domain.Entities.Materials;

namespace DataMgmtModule.Application.Feactures.Materials.Command.AddMaterials
{
    class AddMaterialsCommandHandler : IRequestHandler<AddMaterialsCommand, AddMaterialsDto>
    {
        private readonly IMaterialsRepository _materialsRepository;
        private readonly IMapper _mapper;

        public AddMaterialsCommandHandler(IMaterialsRepository materialRepository, IMapper mapper)
        {
            _materialsRepository = materialRepository;
            _mapper = mapper;
        }
        public async Task<AddMaterialsDto> Handle(AddMaterialsCommand request, CancellationToken cancellationToken)
        {
            var addMaterialEntity = _mapper.Map<DomainBook>(request.AddDto);
            var result = await _materialsRepository.AddMaterials(addMaterialEntity);
            return _mapper.Map<AddMaterialsDto>(result);
        }
    }
}

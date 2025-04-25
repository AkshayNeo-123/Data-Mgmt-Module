using AutoMapper;
using DataMgmtModule.Application.Interface.Persistence;
using MediatR;
using DomainBook = DataMgmtModule.Domain.Entities.Materials;


namespace DataMgmtModule.Application.Feactures.Materials.Command.UpdateMaterials
{
    class UpdateMaterialsCommandHandler : IRequestHandler<UpdateMaterialsCommand, Unit>
    {
        private readonly IMaterialsRepository _materialsRepository;
        private readonly IMapper _mapper;

        public UpdateMaterialsCommandHandler(IMaterialsRepository materialRepository, IMapper mapper)
        {
            _materialsRepository = materialRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateMaterialsCommand request, CancellationToken cancellationToken)
        {
            var updatedMaterial = _mapper.Map<DomainBook>(request.MaterialDto);
            updatedMaterial.MaterialId = request.Id;

            await _materialsRepository.UpdateMaterials(updatedMaterial,request.UserId);

            return Unit.Value;
        }
    }
}

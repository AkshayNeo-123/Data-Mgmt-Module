
using DataMgmtModule.Application.Interface.Persistence;
using MediatR;

namespace DataMgmtModule.Application.Feactures.Materials.Command.DeleteMaterials
{
    public class DeleteMaterialsCommandHandler : IRequestHandler<DeleteMaterialsCommand, Unit>
    {
        private readonly IMaterialsRepository _materialsRepository;

        public DeleteMaterialsCommandHandler(IMaterialsRepository bookRepository)
        {
            _materialsRepository = bookRepository;
        }
        public async Task<Unit> Handle(DeleteMaterialsCommand request, CancellationToken cancellationToken)
        {
            await _materialsRepository.DeleteMaterials(request.MaterialId);
            return Unit.Value;
        }
    }
}

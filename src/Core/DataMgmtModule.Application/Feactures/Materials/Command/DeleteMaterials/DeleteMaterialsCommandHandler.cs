
using DataMgmtModule.Application.Interface.Persistence;
using MediatR;

namespace DataMgmtModule.Application.Feactures.Materials.Command.DeleteMaterials
{
    public class DeleteMaterialsCommandHandler : IRequestHandler<DeleteMaterialsCommand, int>
    {
        private readonly IMaterialsRepository _materialsRepository;

        public DeleteMaterialsCommandHandler(IMaterialsRepository bookRepository)
        {
            _materialsRepository = bookRepository;
        }

        public async Task<int> Handle(DeleteMaterialsCommand request, CancellationToken cancellationToken)
        {
            return await _materialsRepository.DeleteMaterials(request.id);
        }
      
    }
}

using AutoMapper;
using DataMgmtModule.Application.Interface.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DataMgmtModule.Application.Features.InjectionMolding.Command.DeleteInjectionModling
{
    public class DeleteInjectionModlingCommandHandler : IRequestHandler<DeleteInjectionModlingCommand, int>
    {
        private readonly IInjectionMoldingRepository _repository;
        private readonly IMapper _mapper;

        public DeleteInjectionModlingCommandHandler(IInjectionMoldingRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> Handle(DeleteInjectionModlingCommand request, CancellationToken cancellationToken)
        {
            var deleted = await _repository.InjectionmoldigSoftDelete(request.Id,request.DeletedBy);
            return deleted;
        }
    }
}

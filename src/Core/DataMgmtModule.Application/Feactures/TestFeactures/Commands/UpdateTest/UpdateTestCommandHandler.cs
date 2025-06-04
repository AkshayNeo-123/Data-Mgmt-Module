using AutoMapper;
using MediatR;
using DataMgmtModule.Application.Exceptions;
using DataMgmtModule.Application.Interface.Persistence;
using DataMgmtModule.Domain.Entities;
using System.Reflection;

namespace DataMgmtModule.Application.Features.TestFeatures.Commands.UpdateTest
{
    public class UpdateTestCommandHandler :IRequestHandler<UpdateTestCommand, int>
    {
        private readonly ITestRepository _repository;
        private readonly IMapper _mapper;

        public UpdateTestCommandHandler(ITestRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> Handle(UpdateTestCommand request, CancellationToken cancellationToken)
        {
            return await _repository.UpdateTestWithProperties(request);
        }

    }
}

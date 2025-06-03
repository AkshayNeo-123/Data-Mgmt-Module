using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Application.Interface.Persistence;
using MediatR;

namespace DataMgmtModule.Application.Feactures.TestFeactures.Commands.DeleteTest
{
    public class DeleteTestCommandHandler : IRequestHandler<DeleteTestCommand, int>
    {
        private readonly ITestRepository _testRepository;

        public DeleteTestCommandHandler(ITestRepository testRepository)
        {
            _testRepository = testRepository;
        }
        public async Task<int> Handle(DeleteTestCommand request, CancellationToken cancellationToken)
        {
            return await _testRepository.DeleteTest(request.testId,request.deletedBy);
            
        }
    }
}

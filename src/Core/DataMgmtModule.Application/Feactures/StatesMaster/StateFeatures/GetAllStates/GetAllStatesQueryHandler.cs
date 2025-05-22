using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Application.Feactures.ProjectTypeFeactures.Query.GetAllStatus;
using DataMgmtModule.Application.Interface.Persistence;
using DataMgmtModule.Domain.Entities;
using MediatR;

namespace DataMgmtModule.Application.Feactures.StatesMaster.StateFeatures.GetAllStates
{
    public class GetAllStatesQueryHandler : IRequestHandler<GetALlStatesQuery, IEnumerable<States>>
    {

        private readonly IStateRepository _stateRepository;
        public GetAllStatesQueryHandler(IStateRepository stateRepository)
        {
            _stateRepository = stateRepository;
        }
        public async Task<IEnumerable<States>> Handle(GetALlStatesQuery request, CancellationToken cancellationToken)
        {
            return await _stateRepository.GetAllStatesAsync();
        }
    }
}

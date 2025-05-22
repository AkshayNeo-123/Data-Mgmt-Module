using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Application.Interface.Persistence;
using DataMgmtModule.Domain.Entities;
using MediatR;

namespace DataMgmtModule.Application.Feactures.StatesMaster.StateFeatures.AddStateData
{
    public class AddStateQuryHandler : IRequestHandler<AddStateQuery, States>
    {
        private readonly IStateRepository _stateRepository;
      public  AddStateQuryHandler(IStateRepository stateRepository)
        {
            _stateRepository = stateRepository;
        }
        public async Task<States> Handle(AddStateQuery request, CancellationToken cancellationToken)
        {
            var result = new States
            {
                StatesName = request.states.StatesName
            };
            return result;
        }
    }
}

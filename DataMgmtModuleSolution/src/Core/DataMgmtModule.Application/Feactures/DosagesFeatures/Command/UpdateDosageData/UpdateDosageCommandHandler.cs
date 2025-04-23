using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataMgmtModule.Application.Interface.Persistence;
using DataMgmtModule.Domain.Entities;
using MediatR;

namespace DataMgmtModule.Application.Feactures.DosagesFeatures.Command.UpdateDosageData
{
    public class UpdateDosageCommandHandler : IRequestHandler<UpdateDosageCommand, int>
    {
        private readonly IDosageRepository _dosageRepository;
        private readonly IMapper _mapper;
        public UpdateDosageCommandHandler(IDosageRepository dosageRepository,IMapper mapper)
        {
            _dosageRepository = dosageRepository;
            _mapper = mapper;
        }
        public Task<int> Handle(UpdateDosageCommand request, CancellationToken cancellationToken)
        {
            var mapData = _mapper.Map<Dosage>(request.compoundingDataAndComponents.DosageDTO);
            var updatedata=_dosageRepository.UpdateDosageAsync(request.id, mapData);
            return updatedata;
        }
    }
}

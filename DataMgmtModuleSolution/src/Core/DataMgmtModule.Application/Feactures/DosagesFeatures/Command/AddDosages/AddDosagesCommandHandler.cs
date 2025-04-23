using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataMgmtModule.Application.Interface.Persistence;
using DataMgmtModule.Domain.Entities;
using MediatR;

namespace DataMgmtModule.Application.Feactures.DosagesFeatures.Command.AddDosages
{
    public class AddDosagesCommandHandler : IRequestHandler<AddDosagesCommand, int>
    {
        private readonly IDosageRepository _dosageRepository;
        private readonly IMapper _mapper;
        public AddDosagesCommandHandler(IDosageRepository dosageRepository,IMapper mapper)
        {
            _dosageRepository = dosageRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(AddDosagesCommand request, CancellationToken cancellationToken)
        {
            var Data = _mapper.Map<Dosage>(request.compoundingDataAndComponents.DosageDTO);
            var addData = await _dosageRepository.AddDosageAsync(request.id, Data);
            return addData;
        }
    }
}

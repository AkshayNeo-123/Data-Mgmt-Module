using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Application.Interface.Persistence;
using DataMgmtModule.Domain.Entities;
using MediatR;

namespace DataMgmtModule.Application.Feactures.DosagesFeatures.Query.GetDosage
{
    public class GetDosageQueryHandler : IRequestHandler<GetDosageQuery, Dosage>
    {
        private readonly IDosageRepository _dosageRepository;

        public GetDosageQueryHandler(IDosageRepository dosageRepository)
        {
            _dosageRepository = dosageRepository;
        }
        public async Task<Dosage> Handle(GetDosageQuery request, CancellationToken cancellationToken)
        {
            var getData =await _dosageRepository.GetDosageAsync(request.id);

            return getData;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Application.Interface.Persistence;
using DataMgmtModule.Domain.Entities;
using MediatR;

namespace DataMgmtModule.Application.Feactures.DosagesFeatures.Command.DeleteDosage
{
    public class DeleteDosageCommandHandler : IRequestHandler<DeleteDosageCommand, Dosage>
    {
        private readonly IDosageRepository _dosageRepository;

        public DeleteDosageCommandHandler(IDosageRepository dosageRepository)
        {
            _dosageRepository = dosageRepository;
        }

        public Task<Dosage> Handle(DeleteDosageCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }


        //public async Task<Dosage> Handle(DeleteDosageCommand request, CancellationToken cancellationToken)
        //{
        //    var data = await _dosageRepository.GetDosageAsync(request.Id);
        //    var deleteData =await _dosageRepository.DeleteDosageAsync(data.DosageId);
        //    return deleteData;
        //}
    }
}

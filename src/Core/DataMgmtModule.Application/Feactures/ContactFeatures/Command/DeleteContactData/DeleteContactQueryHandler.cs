using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataMgmtModule.Application.Exceptions;
using DataMgmtModule.Application.Interface.Persistence;
using MediatR;

namespace DataMgmtModule.Application.Feactures.ContactFeatures.Command.DeleteContactData
{
    public class DeleteContactQueryHandler : IRequestHandler<DeleteContactQuery, bool>
    {
        private readonly IContactRepository _contactRepository;
        private readonly IMapper _mapper;

        public DeleteContactQueryHandler(IContactRepository contactRepository, IMapper mapper)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
        }
        public async Task<bool> Handle(DeleteContactQuery request, CancellationToken cancellationToken)
        {
            var deleteData =await _contactRepository.GetContactByIdAsync(request.id);
            if (deleteData == null)
            {
                throw new NotFoundException("Data not found");
            }
            var data = await _contactRepository.DeleteContactAsync(deleteData.ContactId,request.deletedBy);
            return true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataMgmtModule.Application.Dtos.ContactDTO;
using DataMgmtModule.Application.Interface.Persistence;
using DataMgmtModule.Domain.Entities;
using MediatR;

namespace DataMgmtModule.Application.Feactures.ContactFeatures.Command.AddContacts
{
    public class AddContactsCommandHandler : IRequestHandler<AddContactsCommand, AddContactDTO>
    {
        private readonly IContactRepository _contactRepository;
         private readonly IMapper _mapper;

        public AddContactsCommandHandler(IContactRepository contactRepository,IMapper mapper)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
        }
        public async Task<AddContactDTO> Handle(AddContactsCommand request, CancellationToken cancellationToken)
        {
            var contactEntity = _mapper.Map<Contact>(request.addContactDTO);
            var addedContact = await _contactRepository.AddContactAsync(contactEntity,request.userId);
            var resultDto = _mapper.Map<AddContactDTO>(addedContact);
            return resultDto;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataMgmtModule.Application.Interface.Persistence;
using MediatR;

namespace DataMgmtModule.Application.Feactures.ContactFeatures.Command.UpdateContacts
{
    public class UpdateContactQueryHandler : IRequestHandler<UpdateContactQuery, bool>
    {
        private readonly IContactRepository _contactRepository;
        private readonly IMapper _mapper;

        public UpdateContactQueryHandler(IContactRepository contactRepository, IMapper mapper)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
        }
        public async Task<bool> Handle(UpdateContactQuery request, CancellationToken cancellationToken)
        {
            var getData =await  _contactRepository.GetContactByIdAsync(request.id);
            if (getData == null) {
                throw new Exception("Updated data not found");

        }
               var mapData=_mapper.Map(request.addContactDTO,getData);
            var updateData =await _contactRepository.UpdateContactAsync( request.id,mapData,request.userId);

            return true;
            }
          
    }
}

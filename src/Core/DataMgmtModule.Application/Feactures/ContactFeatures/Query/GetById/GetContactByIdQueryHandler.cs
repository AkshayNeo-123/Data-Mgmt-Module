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

namespace DataMgmtModule.Application.Feactures.ContactFeatures.Query.GetById
{
    public class GetContactByIdQueryHandler:IRequestHandler<GetContactsByIdQuery,AddContactDTO>
    {
        private readonly IContactRepository _contactRepository;
        private readonly IMapper _mapper;
        public GetContactByIdQueryHandler(IContactRepository contactRepository,IMapper mapper)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
        }

        
        public async Task<AddContactDTO> Handle(GetContactsByIdQuery request, CancellationToken cancellationToken)
        {
            var getdata = await _contactRepository.GetContactByIdAsync(request.id);
            var mapData=_mapper.Map<AddContactDTO>(getdata);
            return mapData;
        }
    }
}

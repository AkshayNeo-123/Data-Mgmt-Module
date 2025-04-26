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

namespace DataMgmtModule.Application.Feactures.ContactFeatures.Query.GetAllContactcsData
{
    public class GetAllContactsQueryhandler : IRequestHandler<GetAllContactsQuery, IEnumerable<AddContactDTO>>
    {
        private readonly IContactRepository _contactRepository;
        private readonly IMapper _mapper;
        public GetAllContactsQueryhandler(IContactRepository contactRepository,IMapper mapper)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<AddContactDTO>> Handle(GetAllContactsQuery request, CancellationToken cancellationToken)
        {
            var getAllData = await _contactRepository.GetAllContacts();
            var mappedResult = _mapper.Map<IEnumerable<AddContactDTO>>(getAllData);
            return mappedResult;

        }
    }
}

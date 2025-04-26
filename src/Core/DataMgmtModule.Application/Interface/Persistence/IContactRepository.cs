using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Domain.Entities;

namespace DataMgmtModule.Application.Interface.Persistence
{
    public interface IContactRepository
    {
        Task<Contact>AddContactAsync(Contact contactDTO,int? userId);
        Task<IEnumerable<Contact>> GetAllContacts();
        Task<Contact> GetContactByIdAsync(int id);
        Task<bool>UpdateContactAsync(int id, Contact contact,int? userId);
        Task<bool>DeleteContactAsync(int id);
    }
}

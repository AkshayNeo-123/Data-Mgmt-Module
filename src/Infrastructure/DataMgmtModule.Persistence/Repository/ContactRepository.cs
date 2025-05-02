using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMgmtModule.Application.Exceptions;
using DataMgmtModule.Application.Interface.Persistence;
using DataMgmtModule.Domain.Entities;
using DataMgmtModule.Domain.Enum.ContactEnum;
using Microsoft.EntityFrameworkCore;

namespace DataMgmtModule.Persistence.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly PersistenceDbContext _persistenceDbContext;
        public ContactRepository(PersistenceDbContext persistenceDbContext)
        {
            _persistenceDbContext = persistenceDbContext; 
        }
        public async Task<Contact> AddContactAsync(Contact contact, int? userId)
        {
            contact.CreatedBy = userId;
            contact.CreatedDate = DateTime.Now;
            var addContact =await _persistenceDbContext.Contacts.AddAsync(contact);
            

             await _persistenceDbContext.SaveChangesAsync();
            return contact;


        }

        public async Task<bool> DeleteContactAsync(int id)
        {
            var getData = await _persistenceDbContext.Contacts.FindAsync(id);
            //if (getData == null)
            //{
            //    throw new NotFoundException($"Contact data with id {id} not found");
            //}
            if (getData.isDelete == false)
            {
                getData.isDelete = true;
                await _persistenceDbContext.SaveChangesAsync();

            }
            //_persistenceDbContext.Contacts.Remove(getData);
            return true;
        }

        public async Task<IEnumerable<Contact>> GetAllContacts()
        {
            var getAllData = await _persistenceDbContext.Contacts.Where(x=>x.isDelete==false).ToListAsync();
            if (getAllData == null)
            {
                throw new NotFoundException("Contact Data Not  Found");
            }
            return getAllData;
        }
        public async Task<IEnumerable<Contact>> GetAllContactsofmanufacturer()
        {
            var getAllData = await _persistenceDbContext.Contacts
                .Where(x => x.ContactType == ContactTypes.Manufacturer || x.ContactType == ContactTypes.Both)
                .ToListAsync();

            if (getAllData == null || !getAllData.Any()) 
            {
                throw new NotFoundException("Contact Data Not Found");
            }

            return getAllData;
        }

        public async Task<IEnumerable<Contact>> GetAllContactsofSupplier()
        {
            var getAllData = await _persistenceDbContext.Contacts
                .Where(x => x.ContactType == ContactTypes.Supplier || x.ContactType == ContactTypes.Both)
                .ToListAsync();

            if (getAllData == null || !getAllData.Any()) 
            {
                throw new NotFoundException("Contact Data Not Found");
            }

            return getAllData;
        }

        public async Task<IEnumerable<Contact>> GetAllContactsofBoth()
        {
            var getAllData = await _persistenceDbContext.Contacts.Where(x => x.ContactType == ContactTypes.Both).ToListAsync();
            if (getAllData == null)
            {
                throw new NotFoundException("Contact Data Not  Found");
            }
            return getAllData;
        }

        public async Task<Contact>GetContactByIdAsync(int id)
        {
            var getData=await _persistenceDbContext.Contacts.FirstOrDefaultAsync(x=>x.ContactId==id);
            if (getData == null)
            {
                throw new NotFoundException($"Contact data with id {id} not found");
            }
            return getData;
        }

        public async Task<bool> UpdateContactAsync(int id, Contact contact, int? userId)
        {
            var existingData = await _persistenceDbContext.Contacts.FindAsync(id);
            if (existingData == null)
            {
                throw new NotFoundException("Data not found");
            }
            contact.UpdatedDate = DateTime.Now;
            contact.updatedBy = userId;
            _persistenceDbContext.Contacts.Update(contact);
            await _persistenceDbContext.SaveChangesAsync();
            return true;
        }

        
    }
}

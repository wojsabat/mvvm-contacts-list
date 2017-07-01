using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using WpfApp3.DAL;
using WpfApp3.Model;

namespace WpfApp3.Services
{
    public class ContactsRepository : IContactsRepository
    {
        private ContactsContext _context = new ContactsContext();

        public Task<List<Contact>> GetAllAsync()
        {
            return _context.Contacts.ToListAsync();
        }

        public Task<Contact> GetAsync(Guid id)
        {
            return _context.Contacts.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Contact> AddAsync(Contact contact)
        {
            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();
            return contact;
        }

        public async Task<Contact> UpdateAsync(Contact contact)
        {
            if (!_context.Contacts.Any(c => c.Id == contact.Id))
            {
                _context.Contacts.Attach(contact);
            }
            _context.Entry(contact).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return contact;
        }

        public async Task DeleteAsync(Guid id)
        {
            var contact = _context.Contacts.FirstOrDefault(c => c.Id == id);
            if (contact != null)
            {
                _context.Contacts.Remove(contact);
            }
            await _context.SaveChangesAsync();
        }
    }
}
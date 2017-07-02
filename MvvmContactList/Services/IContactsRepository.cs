using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MvvmContactList.Model;

namespace MvvmContactList.Services
{
    public interface IContactsRepository
    {
        Task<List<Contact>> GetAllAsync();
        Task<Contact> GetAsync(Guid id);
        Task<Contact> AddAsync(Contact contact);
        Task<Contact> UpdateAsync(Contact contact);
        Task DeleteAsync(Guid id);
    }
}
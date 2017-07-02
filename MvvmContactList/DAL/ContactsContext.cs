using System.Data.Entity;
using MvvmContactList.Model;

namespace MvvmContactList.DAL
{
    public class ContactsContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }
    }
}
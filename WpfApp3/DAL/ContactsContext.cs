using System.Data.Entity;
using WpfApp3.Model;

namespace WpfApp3.DAL
{
    public class ContactsContext : DbContext
    {
        private DbSet<Contact> Contacts { get; set; }
    }
}
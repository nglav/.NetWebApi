using ContactsApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactsApi.Data
{
    public class ContactApiDbContext : DbContext
    {
        public ContactApiDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; }
    }
}

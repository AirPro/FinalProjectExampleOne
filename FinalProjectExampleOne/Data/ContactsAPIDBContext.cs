using FinalProjectExampleOne.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalProjectExampleOne.Data
{
    public class ContactsAPIDBContext : DbContext
    {
        public ContactsAPIDBContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Contact>? Contacts { get; set; } = null;

        public DbSet<Amplifier>? Amplifiers { get; set; } = null;
        public DbSet<Guitar>? Guitars { get; set; } = null;
        public DbSet<Pedal>? Pedals { get; set; } = null;
    }
}

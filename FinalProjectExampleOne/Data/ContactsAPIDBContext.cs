using FinalProjectExampleOne.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalProjectExampleOne.Data
{
    public class ContactsAPIDBContext : DbContext
    {
        public ContactsAPIDBContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Contact> Contacts { get; set; }

        // public DbSet<Amplifier> Amplifiers { get; set; }
        // public DbSet<Guitar> Guitars { get; set; }
        // public DbSet<Pedal> Pedals { get; set; }
    }
}

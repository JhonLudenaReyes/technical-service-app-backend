using Microsoft.EntityFrameworkCore;
using TechnicalService.Models;

namespace TechnicalService.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Role> Roles { get; set; }

        public DbSet<Permission> Permissions { get; set; }

        public DbSet<Profile> Profiles { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Gender> Genders { get; set; }

        public DbSet<Person> Persons { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Client> Clients { get; set; }
    }
}

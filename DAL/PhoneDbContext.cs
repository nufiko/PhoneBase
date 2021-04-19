using Microsoft.EntityFrameworkCore;
using PhoneBase.DAL.Model;

namespace PhoneBase.DAL
{
    public class PhoneDbContext : DbContext
    {
        public PhoneDbContext(DbContextOptions options) : base(options)
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<Phone> Phones { get; set; }
    }
}

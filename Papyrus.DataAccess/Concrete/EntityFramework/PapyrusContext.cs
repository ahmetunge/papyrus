
using Microsoft.EntityFrameworkCore;
using Papyrus.DataAccess.Concrete.EntityFramework.Mappings;
using Papyrus.Entities;
using Papyrus.Entities.Concrete;

namespace Papyrus.DataAccess.Concrete.EntityFramework
{
    public class PapyrusContext : DbContext
    {
        public PapyrusContext(DbContextOptions<PapyrusContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            new BookMap(builder.Entity<Book>());
            new UserMap(builder.Entity<User>());
            new RoleMap(builder.Entity<Role>());
            new UserRoleMap(builder.Entity<UserRole>());

        }
    }
}

using Core.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Papyrus.DataAccess.Concrete.EntityFramework.Mappings;
using Papyrus.Entities;

namespace Papyrus.DataAccess.Concrete.EntityFramework
{
    public class PapyrusContext : DbContext
    {
        public PapyrusContext(DbContextOptions<PapyrusContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            new BookMap(builder.Entity<Book>());
            new UserMap(builder.Entity<User>());
            new RoleMap(builder.Entity<Role>());
            new UserRoleMap(builder.Entity<UserRole>());

        }
    }
}
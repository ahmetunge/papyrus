
using Core.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Papyrus.DataAccess.Concrete.EntityFramework.DbConfiguration;
using Papyrus.Entities.Concrete;

namespace Papyrus.DataAccess.Concrete.EntityFramework
{
    public class PapyrusContext : DbContext
    {
        public PapyrusContext(DbContextOptions<PapyrusContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Catalog> Catalogs { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new BookConfiguration());
            builder.ApplyConfiguration(new LogConfiguration());
            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new UserRoleConfiguration());
            builder.ApplyConfiguration(new CatalogConfiguration());
            builder.ApplyConfiguration(new GenreConfiguration());
        }
    }
}
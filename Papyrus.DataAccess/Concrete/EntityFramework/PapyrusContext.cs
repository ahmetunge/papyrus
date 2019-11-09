
using Microsoft.EntityFrameworkCore;
using Papyrus.Entities;

namespace Papyrus.DataAccess.Concrete.EntityFramework
{
    public class PapyrusContext : DbContext
    {
        public PapyrusContext(DbContextOptions<PapyrusContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
    }
}
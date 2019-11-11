using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Papyrus.Entities;

namespace Papyrus.DataAccess.Concrete.EntityFramework.Mappings
{
    public class BookMap
    {
        public BookMap(EntityTypeBuilder<Book> entity)
        {
            entity.HasKey(b => b.Id);

            entity.Property(b => b.Name)
            .HasMaxLength(500)
            .IsRequired(true);

            entity.Property(b => b.Summary)
            .HasMaxLength(1000)
            .IsRequired(false);
        }
    }
}
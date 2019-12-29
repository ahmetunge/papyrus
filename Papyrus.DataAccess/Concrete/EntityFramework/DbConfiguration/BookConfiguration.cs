using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Papyrus.Entities.Concrete;

namespace Papyrus.DataAccess.Concrete.EntityFramework.DbConfiguration
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
             builder.HasKey(b => b.Id);

            builder.Property(b => b.Name)
            .HasMaxLength(500)
            .IsRequired(true);

            builder.Property(b => b.Summary)
            .HasMaxLength(1000)
            .IsRequired(false);
        }
    }
}
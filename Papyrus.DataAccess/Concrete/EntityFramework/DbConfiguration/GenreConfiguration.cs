using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Papyrus.Entities.Concrete;

namespace Papyrus.DataAccess.Concrete.EntityFramework.DbConfiguration
{
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.HasKey(g => g.Id);

            builder.Property(g => g.Name)
            .HasMaxLength(150)
            .IsRequired(true);

            builder.Property(g => g.Description)
            .HasMaxLength(500);

            builder.HasOne(g => g.Category)
            .WithMany(c => c.Genres)
            .HasForeignKey(g => g.CategoryId);

            builder.HasMany(g => g.Books)
            .WithOne(b => b.Genre)
            .HasForeignKey(b => b.GenreId);
        }
    }
}
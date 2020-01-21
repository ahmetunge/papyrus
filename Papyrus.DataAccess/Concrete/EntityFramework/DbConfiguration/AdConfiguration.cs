using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Papyrus.Entities.Concrete;

namespace Papyrus.DataAccess.Concrete.EntityFramework.DbConfiguration
{
    public class AdConfiguration : IEntityTypeConfiguration<Ad>
    {
        public void Configure(EntityTypeBuilder<Ad> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Title)
            .IsRequired(true)
            .HasMaxLength(250);

            builder.Property(a => a.Description)
            .IsRequired(false)
            .HasMaxLength(750);

            builder.HasOne(a => a.Book)
            .WithOne(b => b.Ad)
            .HasForeignKey<Book>(b => b.AdId);

            builder.HasMany(a => a.Photos)
            .WithOne(p => p.Ad)
            .HasForeignKey(p => p.AdId);
        }
    }
}
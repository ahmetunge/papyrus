using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Papyrus.Entities.Concrete;
using Papyrus.Entities.Concrete.Enums;

namespace Papyrus.DataAccess.Concrete.EntityFramework.DbConfiguration
{
    public class AdConfiguration : IEntityTypeConfiguration<Ad>
    {
        public void Configure(EntityTypeBuilder<Ad> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Title)
            .HasMaxLength(150)
            .IsRequired(true);

            builder.Property(a => a.Description)
            .HasMaxLength(500)
            .IsRequired(false);

            builder.Property(a => a.Status)
            .IsRequired(true)
            .HasDefaultValue(AdStatus.Active);

            builder.HasOne(a => a.Member)
            .WithMany(m => m.Ads)
            .HasForeignKey(a => a.MemberId);

            builder.HasOne(a => a.Product)
            .WithOne(p => p.Ad)
            .HasForeignKey<Product>(a => a.AdId);

            builder.HasMany(a => a.Photos)
            .WithOne(p => p.Ad)
            .HasForeignKey(p => p.AdId);
        }
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Papyrus.Entities.Concrete;

namespace Papyrus.DataAccess.Concrete.EntityFramework.DbConfiguration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
            .HasMaxLength(250)
            .IsRequired(true);

            builder.HasOne(p => p.Ad)
            .WithOne(a => a.Product)
            .HasForeignKey<Product>(p => p.AdId);

            builder.HasMany(p => p.ProductPropertyValues)
            .WithOne(ppv => ppv.Product)
            .HasForeignKey(ppv => ppv.ProductId);

        }
    }
}
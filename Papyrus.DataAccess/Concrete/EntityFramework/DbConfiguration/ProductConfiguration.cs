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

            builder.HasOne(p => p.Category)
            .WithMany(c => c.Products)
            .HasForeignKey(p => p.CategoryId);

            builder.HasMany(p => p.ProductProperties)
            .WithOne(pp => pp.Product)
            .HasForeignKey(pp => pp.ProductId);

            builder.HasOne(p => p.Ad)
            .WithOne(a => a.Product)
            .HasForeignKey<Product>(p => p.AdId);

        }
    }
}
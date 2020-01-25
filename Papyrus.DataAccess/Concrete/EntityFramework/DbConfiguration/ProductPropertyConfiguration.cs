using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Papyrus.Entities.Concrete;

namespace Papyrus.DataAccess.Concrete.EntityFramework.DbConfiguration
{
    public class ProductPropertyConfiguration : IEntityTypeConfiguration<ProductProperty>
    {
        public void Configure(EntityTypeBuilder<ProductProperty> builder)
        {
            builder.HasKey(pp => new { pp.ProductId, pp.PropertyTypeId, pp.PropertyValueId });

            builder.HasOne(pp => pp.Product)
            .WithMany(p => p.ProductProperties)
            .HasForeignKey(pp => pp.ProductId);

            builder.HasOne(pp => pp.PropertyType)
            .WithMany(p => p.ProductProperties)
            .HasForeignKey(pp => pp.PropertyTypeId);

            builder.HasOne(pp => pp.PropertyValue)
            .WithMany(p => p.ProductProperties)
            .HasForeignKey(pp => pp.PropertyValueId);
        }
    }
}
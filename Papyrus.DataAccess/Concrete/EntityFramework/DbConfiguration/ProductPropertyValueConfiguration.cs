using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Papyrus.Entities.Concrete;

namespace Papyrus.DataAccess.Concrete.EntityFramework.DbConfiguration
{
    public class ProductPropertyValueConfiguration : IEntityTypeConfiguration<ProductPropertyValue>
    {
        public void Configure(EntityTypeBuilder<ProductPropertyValue> builder)
        {
            builder.HasKey(ppv => new {ppv.PropertyId,ppv.ProductId});

            builder.Property(ppv => ppv.Value)
            .IsRequired(true)
            .HasMaxLength(250);

            builder.HasOne(ppv => ppv.Product)
            .WithMany(p => p.ProductPropertyValues)
            .HasForeignKey(ppv => ppv.ProductId);

            builder.HasOne(ppv => ppv.Property)
            .WithMany(p => p.ProductPropertyValues)
            .HasForeignKey(ppv => ppv.PropertyId)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
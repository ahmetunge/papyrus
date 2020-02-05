using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Papyrus.Entities.Concrete;

namespace Papyrus.DataAccess.Concrete.EntityFramework.DbConfiguration
{
    public class PropertyConfiguration : IEntityTypeConfiguration<Property>
    {
        public void Configure(EntityTypeBuilder<Property> builder)
        {
         
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
            .HasMaxLength(150)
            .IsRequired(true);

            builder.HasOne(p => p.PropertyType)
            .WithMany(pt => pt.Properties)
            .HasForeignKey(p => p.PropertyTypeId);

            builder.HasMany(p => p.ProductPropertyValues)
            .WithOne(ppv => ppv.Property)
            .HasForeignKey(ppv => ppv.PropertyId);

        }
    }
}
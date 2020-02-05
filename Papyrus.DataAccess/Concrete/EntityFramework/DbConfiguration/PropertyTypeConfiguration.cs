using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Papyrus.Entities.Concrete;

namespace Papyrus.DataAccess.Concrete.EntityFramework.DbConfiguration
{
    public class PropertyTypeConfiguration : IEntityTypeConfiguration<PropertyType>
    {
        public void Configure(EntityTypeBuilder<PropertyType> builder)
        {
            builder.HasKey(pt => pt.Id);

            builder.Property(pt => pt.Name)
            .HasMaxLength(150)
            .IsRequired(true);

            builder.HasMany(pt => pt.Properties)
            .WithOne(p => p.PropertyType)
            .HasForeignKey(p => p.PropertyTypeId);

        }
    }
}
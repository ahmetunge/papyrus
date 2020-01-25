using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Papyrus.Entities.Concrete;

namespace Papyrus.DataAccess.Concrete.EntityFramework.DbConfiguration
{
    public class PropertyTypeConfiguration : IEntityTypeConfiguration<PropertyType>
    {
        /*
                public string Name { get; set; }
        public string Description { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }

        public ICollection<PropertyValue> PropertyValues { get; set; }

        public ICollection<ProductProperty> ProductProperties { get; set; }
        */
        public void Configure(EntityTypeBuilder<PropertyType> builder)
        {
            builder.HasKey(pt => pt.Id);

            builder.Property(pt => pt.Name)
            .HasMaxLength(100)
            .IsRequired(true);

            builder.Property(pt => pt.Description)
            .HasMaxLength(500)
            .IsRequired(false);

            builder.HasOne(pt => pt.Category)
            .WithMany(c => c.PropertyTypes)
            .HasForeignKey(pt => pt.CategoryId);

            builder.HasMany(pt => pt.PropertyValues)
            .WithOne(pv => pv.PropertyType)
            .HasForeignKey(pv => pv.PropertyTypeId);

            builder.HasMany(pt => pt.ProductProperties)
            .WithOne(pp => pp.PropertyType)
            .HasForeignKey(pp => pp.PropertyTypeId);
        }
    }
}
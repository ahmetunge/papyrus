using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Papyrus.Entities.Concrete;

namespace Papyrus.DataAccess.Concrete.EntityFramework.DbConfiguration
{
    public class PropertyValueConfiguration : IEntityTypeConfiguration<PropertyValue>
    {
        /*
              public string Name { get; set; }
        public string Description { get; set; }
        public Guid PropertyTypeId { get; set; }
        public PropertyType PropertyType { get; set; }
        public ICollection<ProductProperty> ProductProperties { get; set; }
        */
        public void Configure(EntityTypeBuilder<PropertyValue> builder)
        {
            builder.HasKey(pv => pv.Id);

            builder.Property(pv => pv.Name)
            .HasMaxLength(100)
            .IsRequired(true);

            builder.Property(pv => pv.Description)
            .HasMaxLength(500)
            .IsRequired(false);

            builder.HasOne(pv => pv.PropertyType)
            .WithMany(pt => pt.PropertyValues)
            .HasForeignKey(pv => pv.PropertyTypeId);

            builder.HasMany(pv => pv.ProductProperties)
            .WithOne(pp => pp.PropertyValue)
            .HasForeignKey(pp => pp.PropertyValueId);
        }
    }
}
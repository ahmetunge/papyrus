using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Papyrus.Entities.Concrete;

namespace Papyrus.DataAccess.Concrete.EntityFramework.DbConfiguration
{
    public class CatalogConfiguration : IEntityTypeConfiguration<Catalog>
    {
        public void Configure(EntityTypeBuilder<Catalog> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
            .HasMaxLength(150)
            .IsRequired(true);

            builder.Property(c => c.Description)
            .HasMaxLength(500);

        }
    }
}
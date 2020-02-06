using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Papyrus.Entities.Concrete;

namespace Papyrus.DataAccess.Concrete.EntityFramework.DbConfiguration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {

        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
            .HasMaxLength(150)
            .IsRequired(true);

            builder.Property(c => c.Description)
            .HasMaxLength(500)
            .IsRequired(false);

            builder.HasMany(c => c.Properties)
            .WithOne(p => p.Category)
            .HasForeignKey(p => p.CategoryId);

            builder.HasMany(c => c.Ads)
            .WithOne(a => a.Category)
            .HasForeignKey(a => a.CategoryId);

        }
    }
}
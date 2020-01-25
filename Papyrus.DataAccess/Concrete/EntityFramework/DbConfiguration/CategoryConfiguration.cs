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
            .HasMaxLength(100)
            .IsRequired(true);

            builder.Property(c => c.Description)
            .HasMaxLength(500)
            .IsRequired(false);

            builder.HasMany(c => c.PropertyTypes)
            .WithOne(pt => pt.Category)
            .HasForeignKey(pt => pt.CategoryId);

            builder.HasMany(c => c.Products)
            .WithOne(p => p.Category)
            .HasForeignKey(p => p.CategoryId);


        }
    }
}
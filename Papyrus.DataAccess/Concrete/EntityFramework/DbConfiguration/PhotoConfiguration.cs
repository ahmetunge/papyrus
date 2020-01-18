using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Papyrus.Entities.Concrete;

namespace Papyrus.DataAccess.Concrete.EntityFramework.DbConfiguration
{
    public class PhotoConfiguration : IEntityTypeConfiguration<Photo>
    {
        public void Configure(EntityTypeBuilder<Photo> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.DateAdded)
            .IsRequired(true);

            builder.Property(p => p.IsMain)
            .IsRequired(true);

            builder.Property(p => p.Url)
            .IsRequired(true);
        }
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Papyrus.Entities.Concrete;

namespace Papyrus.DataAccess.Concrete.EntityFramework.DbConfiguration
{
    public class LogConfiguration : IEntityTypeConfiguration<Log>
    {
        public void Configure(EntityTypeBuilder<Log> builder)
        {
            builder.HasKey(l => l.Id);

            builder.Property(l => l.Detail)
            .IsRequired(true);

            builder.Property(l => l.Date)
            .IsRequired(true);

            builder.Property(l => l.Audit)
            .IsRequired(true)
            .HasMaxLength(150);
        }
    }
}
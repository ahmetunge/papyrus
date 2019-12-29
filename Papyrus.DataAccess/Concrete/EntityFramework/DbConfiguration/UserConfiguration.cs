using Core.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Papyrus.DataAccess.Concrete.EntityFramework.DbConfiguration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
             builder.HasKey(u => u.Id);

            builder.Property(u => u.Firstname)
            .IsRequired(true)
            .HasMaxLength(50);

            builder.Property(u => u.Lastname)
            .IsRequired(true)
            .HasMaxLength(50);

            builder.Property(u => u.Email)
            .IsRequired(true)
            .HasMaxLength(50);

            builder.Property(u => u.PasswordHash)
            .IsRequired(true)
            .HasMaxLength(500);

            builder.Property(u => u.PasswordSalt)
            .IsRequired(true)
            .HasMaxLength(500);

            builder.Property(u => u.Status)
            .IsRequired(true);
        }
    }
}
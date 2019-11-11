using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Papyrus.Entities.Concrete;

namespace Papyrus.DataAccess.Concrete.EntityFramework.Mappings
{
    public class UserMap
    {
        public UserMap(EntityTypeBuilder<User> entity)
        {
            entity.HasKey(u => u.Id);

            entity.Property(u => u.Firstname)
            .IsRequired(true)
            .HasMaxLength(50);

            entity.Property(u => u.Lastname)
            .IsRequired(true)
            .HasMaxLength(50);

            entity.Property(u => u.Email)
            .IsRequired(true)
            .HasMaxLength(50);

            entity.Property(u => u.PasswordHash)
            .IsRequired(true)
            .HasMaxLength(500);

            entity.Property(u => u.PasswordSalt)
            .IsRequired(true)
            .HasMaxLength(500);

            entity.Property(u => u.Status)
            .IsRequired(true);

        }
    }
}
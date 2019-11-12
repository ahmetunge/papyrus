using Core.Entities.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Papyrus.DataAccess.Concrete.EntityFramework.Mappings
{
    public class RoleMap
    {
        public RoleMap(EntityTypeBuilder<Role> entity)
        {
            entity.HasKey(r => r.Id);

            entity.Property(r => r.Name)
            .HasMaxLength(50)
            .IsRequired();
        }
    }
}
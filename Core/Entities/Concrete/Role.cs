using System;
using System.Collections.Generic;

namespace Core.Entities.Concrete
{
    public class Role : EntityBase<Guid>, IEntity
    {
        public string Name { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
using System;
using System.Collections.Generic;

namespace Core.Entities.Concrete
{
    public class User : EntityBase<Guid>, IEntity
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public byte Status { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }

    }
}
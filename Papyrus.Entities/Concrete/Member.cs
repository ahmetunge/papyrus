using System;
using System.Collections.Generic;
using Core.Entities;
using Core.Entities.Concrete;

namespace Papyrus.Entities.Concrete
{
    public class Member: EntityBase<Guid>,IEntity
    {
        public Member()
        {
            Ads = new HashSet<Ad>();
        }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public ICollection<Ad> Ads { get; set; }
    }
}
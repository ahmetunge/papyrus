using System;
using System.Collections.Generic;
using Core.Entities;

namespace Papyrus.Entities.Concrete
{
    public class Ad : EntityBase<Guid>, IEntity
    {
        public Ad()
        {
            Photos = new HashSet<Photo>();
        }
        public string Title { get; set; }
        public string Description { get; set; }
        public Book Book { get; set; }
        public ICollection<Photo> Photos { get; set; }
        public Member Member { get; set; }
        public Guid MemberId { get; set; }

    }
}
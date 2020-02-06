using System;
using System.Collections.Generic;
using Core.Entities;
using Papyrus.Entities.Concrete.Enums;

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
        public AdStatus Status { get; set; }
        public Member Member { get; set; }
        public Guid MemberId { get; set; }
        public Product Product { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<Photo> Photos { get; set; }

    }
}
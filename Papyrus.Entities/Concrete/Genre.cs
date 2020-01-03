using System;
using System.Collections.Generic;
using Core.Entities;

namespace Papyrus.Entities.Concrete
{
    public class Genre : EntityBase<Guid>, IEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public Category Category { get; set; }
        public Guid CategoryId { get; set; }

        public List<Book> Books{ get; set; }
    }
}
using System;
using System.Collections.Generic;
using Core.Entities;

namespace Papyrus.Entities.Concrete
{
    public class Genre : EntityBase<Guid>, IEntity
    {
        public Genre()
        {
            Books = new HashSet<Book>();
        }
        public string Name { get; set; }

        public string Description { get; set; }

        public Catalog Catalog { get; set; }
        public Guid CatalogId { get; set; }

        public ICollection<Book> Books{ get; set; }
    }
}
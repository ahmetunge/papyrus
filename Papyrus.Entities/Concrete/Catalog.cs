using System;
using System.Collections.Generic;
using Core.Entities;

namespace Papyrus.Entities.Concrete
{
    public class Catalog:EntityBase<Guid>,IEntity
    {
        public Catalog()
        {
            Genres = new HashSet<Genre>();
        }
        public string  Name{ get; set; }

        public string Description { get; set; }

        public ICollection<Genre> Genres{ get; set; }
    }
}
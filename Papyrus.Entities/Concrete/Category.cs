using System;
using System.Collections.Generic;
using Core.Entities;

namespace Papyrus.Entities.Concrete
{
    public class Category:EntityBase<Guid>,IEntity
    {
        public string  Name{ get; set; }

        public string Description { get; set; }

        public List<Genre> Genres{ get; set; }
    }
}
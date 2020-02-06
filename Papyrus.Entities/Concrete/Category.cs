using System;
using System.Collections.Generic;
using Core.Entities;

namespace Papyrus.Entities.Concrete
{
    public class Category: EntityBase<Guid>,IEntity
    {
        public Category()
        {
            Properties = new HashSet<Property>();
            Ads = new HashSet<Ad>();
        }
        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<Property> Properties { get; set; }
        
        public ICollection<Ad> Ads { get; set; }
    }
}
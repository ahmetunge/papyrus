using System;
using System.Collections.Generic;
using Core.Entities;

namespace Papyrus.Entities.Concrete
{
    public class Category: EntityBase<Guid>,IEntity
    {
        public Category()
        {
            PropertyTypes = new HashSet<PropertyType>();
            Products = new HashSet<Product>();
        }
        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<PropertyType> PropertyTypes { get; set; }
        
        public ICollection<Product> Products { get; set; }
    }
}
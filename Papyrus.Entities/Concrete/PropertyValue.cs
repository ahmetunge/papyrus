using System;
using System.Collections.Generic;
using Core.Entities;

namespace Papyrus.Entities.Concrete
{
    public class PropertyValue: EntityBase<Guid>,IEntity
    {
        public PropertyValue()
        {
            ProductProperties = new HashSet<ProductProperty>();
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid PropertyTypeId { get; set; }
        public PropertyType PropertyType { get; set; }
        public ICollection<ProductProperty> ProductProperties { get; set; }
    }
}
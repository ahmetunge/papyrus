using System;
using System.Collections.Generic;
using Core.Entities;

namespace Papyrus.Entities.Concrete
{
    public class PropertyType : EntityBase<Guid>, IEntity
    {
        public PropertyType()
        {
            PropertyValues = new HashSet<PropertyValue>();
            ProductProperties = new HashSet<ProductProperty>();
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }

        public ICollection<PropertyValue> PropertyValues { get; set; }

        public ICollection<ProductProperty> ProductProperties { get; set; }
    }
}
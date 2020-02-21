using System;
using System.Collections.Generic;
using Core.Entities;
using Papyrus.Entities.Concrete.Enums;

namespace Papyrus.Entities.Concrete
{
    public class Property : EntityBase<Guid>, IEntity
    {
        public Property()
        {
            ProductPropertyValues = new HashSet<ProductPropertyValue>();
        }
        public string Name { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
        //  public PropertyType PropertyType { get; set; }
        public PropertyType PropertyType { get; set; }
        // public Guid PropertyTypeId { get; set; }

        public ICollection<ProductPropertyValue> ProductPropertyValues { get; set; }
    }
}
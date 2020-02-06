using System;
using System.Collections.Generic;
using Core.Entities;

namespace Papyrus.Entities.Concrete
{
    public class Product : EntityBase<Guid>, IEntity
    {
        public Product()
        {
            ProductPropertyValues = new HashSet<ProductPropertyValue>();
        }
        public string Name { get; set; }
        public Guid AdId { get; set; }
        public Ad Ad { get; set; }
        public ICollection<ProductPropertyValue> ProductPropertyValues { get; set; }
    }
}
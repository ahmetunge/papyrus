using System;
using System.Collections.Generic;
using Core.Entities;

namespace Papyrus.Entities.Concrete
{
    public class Product : EntityBase<Guid>, IEntity
    {
        public Product()
        {
            ProductProperties = new HashSet<ProductProperty>();
        }
       
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<ProductProperty> ProductProperties { get; set; }
        public Guid AdId { get; set; }
        public Ad Ad { get; set; }
    }
}
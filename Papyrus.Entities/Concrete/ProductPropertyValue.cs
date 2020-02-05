using System;
using Core.Entities;

namespace Papyrus.Entities.Concrete
{
    public class ProductPropertyValue:IEntity
    {
        public Guid ProductId { get; set; }
        public Product Product { get; set; }

        public Guid PropertyId { get; set; }
        public Property Property { get; set; }

        public string Value { get; set; }

    }
}
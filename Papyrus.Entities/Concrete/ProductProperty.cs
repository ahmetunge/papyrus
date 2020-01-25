using System;

namespace Papyrus.Entities.Concrete
{
    public class ProductProperty
    {
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public Guid PropertyTypeId { get; set; }
        public PropertyType PropertyType { get; set; }
        public Guid PropertyValueId { get; set; }
        public PropertyValue PropertyValue { get; set; }
    }
}
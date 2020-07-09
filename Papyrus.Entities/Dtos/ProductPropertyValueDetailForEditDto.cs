using System;

namespace Papyrus.Entities.Dtos
{
    public class ProductPropertyValueDetailForEditDto
    {
        public Guid ProductId { get; set; }
        public Guid PropertyId { get; set; }
        public string Value { get; set; }
    }
}
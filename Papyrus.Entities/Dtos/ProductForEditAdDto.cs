using System;
using System.Collections.Generic;

namespace Papyrus.Entities.Dtos
{
    public class ProductForEditAdDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<ProductPropertyValueForEditAdDto> ProductPropertyValues { get; set; }
    }
}
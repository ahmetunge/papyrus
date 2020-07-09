using System.Collections.Generic;

namespace Papyrus.Entities.Dtos
{
    public class ProductDetailForEditDto
    {
        public string Name { get; set; }

        public List<ProductPropertyValueDetailForEditDto> ProductPropertyValues { get; set; }
    }
}
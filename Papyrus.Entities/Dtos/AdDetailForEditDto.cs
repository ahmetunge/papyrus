using System;

namespace Papyrus.Entities.Dtos
{
    public class AdDetailForEditDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid CategoryId { get; set; }
        public ProductDetailForEditDto Product { get; set; }
    }
}
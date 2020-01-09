using System;

namespace Papyrus.Entities.Dtos
{
    public class BookForDetailDto
    {
        public string Name { get; set; }

        public string Summary { get; set; }
        public Guid GenreId { get; set; }

        public Guid CatalogId { get; set; }
    }
}
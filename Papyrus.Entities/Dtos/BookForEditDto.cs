using System;

namespace Papyrus.Entities.Dtos
{
    public class BookForEditDto
    {
        public string Name { get; set; }
        public string Summary { get; set; }

        public Guid GenreId { get; set; }
    }
}
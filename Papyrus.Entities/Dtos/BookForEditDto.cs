using System;

namespace Papyrus.Entities.Dtos
{
    public class BookForEditDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Summary { get; set; }
    }
}
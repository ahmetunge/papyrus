using System;
using System.Collections.Generic;

namespace Papyrus.Entities.Dtos
{
    public class CatalogToEditBookDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<KeyValueDto> Genres { get; set; }
    }
}
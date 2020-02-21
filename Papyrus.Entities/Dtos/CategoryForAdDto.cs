using System;
using System.Collections.Generic;

namespace Papyrus.Entities.Dtos
{
    public class CategoryForAdDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<PropertyForAdDto> Properties { get; set; }
    }
}
using System;
using Papyrus.Entities.Concrete.Enums;

namespace Papyrus.Entities.Dtos
{
    public class PropertyForAdDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public PropertyType PropertyType { get; set; }
    }
}
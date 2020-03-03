using System.Collections.Generic;

namespace Papyrus.Entities.Dtos
{
    public class ProductForCreationAdDto
    {
         public string Name { get; set; }
        public ICollection<ProducPropertyValueForCreationAdDto> ProductPropertyValues { get; set; }
    }
}
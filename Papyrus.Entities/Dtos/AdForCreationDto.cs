using System;
using Papyrus.Entities.Concrete.Enums;

namespace Papyrus.Entities.Dtos
{
    public class AdForCreationDto
    {
        public AdForCreationDto()
        {
        }
        public string Title { get; set; }
        public string Description { get; set; }
        public ProductForCreationAdDto Product { get; set; }
        public Guid CategoryId { get; set; }

    }
}
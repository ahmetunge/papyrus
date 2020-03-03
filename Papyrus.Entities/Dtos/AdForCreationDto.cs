using System;

namespace Papyrus.Entities.Dtos
{
    public class AdForCreationDto
    {
        public string Title { get; set; }
        public Guid CategoryId { get; set; }
        public string Description { get; set; }

        public Guid MemberId { get; set; }
    }
}
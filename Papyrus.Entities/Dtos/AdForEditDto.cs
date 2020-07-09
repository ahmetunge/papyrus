using System;
using Papyrus.Entities.Concrete.Enums;

namespace Papyrus.Entities.Dtos
{
    public class AdForEditDto
    {
        public AdForEditDto()
        {
            Status = AdStatus.Active;
        }

        public Guid Id { get; set; }
        public AdStatus Status { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public ProductForEditAdDto Product { get; set; }
        public Guid CategoryId { get; set; }
    }
}
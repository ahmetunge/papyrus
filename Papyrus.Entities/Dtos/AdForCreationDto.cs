using System;
using Papyrus.Entities.Concrete.Enums;

namespace Papyrus.Entities.Dtos
{
    public class AdForCreationDto
    {
        public AdForCreationDto()
        {
            Status=AdStatus.Active;
        }
        public string Title { get; set; }
        public string Description { get; set; }
        public AdStatus Status { get;private set; }
       // public Member Member { get; set; }
        public Guid MemberId { get; set; }
        public ProductForCreationAdDto Product { get; set; }
        public Guid CategoryId { get; set; }
     //   public Category Category { get; set; }
      //  public ICollection<Photo> Photos { get; set; }
    }
}
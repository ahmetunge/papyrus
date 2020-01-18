using System;
using Core.Entities;

namespace Papyrus.Entities.Concrete
{
    public class Photo : EntityBase<Guid>, IEntity
    {
        public string Url { get; set; }
        public DateTime DateAdded { get; set; }
        public bool IsMain { get; set; }
        public string PublicId { get; set; }
    }
}
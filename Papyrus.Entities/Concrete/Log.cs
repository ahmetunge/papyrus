using System;
using Core.Entities;

namespace Papyrus.Entities.Concrete
{
    public class Log : EntityBase<Guid>, IEntity
    {
        public string Detail { get; set; }
        public DateTime Date { get; set; }
        public string Audit { get; set; }
    }
}
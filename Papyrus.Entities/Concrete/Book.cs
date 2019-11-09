using System;
using Core.Entities;

namespace Papyrus.Entities
{
    public class Book : EntityBase<Guid>, IEntity
    {
        public string Name { get; set; }

        public string Summary { get; set; }

    }
}
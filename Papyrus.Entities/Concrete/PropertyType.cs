using System;
using System.Collections.Generic;
using Core.Entities;

namespace Papyrus.Entities.Concrete
{
    public class PropertyType : EntityBase<Guid>, IEntity
    {
        public PropertyType()
        {
            Properties = new HashSet<Property>();
        }
        public string Name { get; set; }
        public ICollection<Property> Properties { get; set; }
    }
}
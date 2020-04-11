using System;
using System.Collections.Generic;
using Core.Entities;
using Papyrus.Entities.Concrete.Enums;

namespace Papyrus.Entities.Dtos
{
    public class AdForDetailDto : DtoBase<Guid>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public AdStatus Status { get; set; }
        public string CategoryName { get; set; }

        public List<ProducPropertyValueForDetailAdDto> ProductPropertyValues { get; set; }


    }
}
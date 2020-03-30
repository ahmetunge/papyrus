using System;
using Core.Entities;

namespace Papyrus.Entities.Dtos
{
    public class MemberAdForListDto : DtoBase<Guid>
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
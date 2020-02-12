using AutoMapper;
using Papyrus.Entities.Concrete;
using Papyrus.Entities.Dtos;

namespace Papyrus.Business.Mapping.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Property, KeyValueDto>();
            CreateMap<Category, CategoryForAdDto>();
            CreateMap<AdForCreationDto, Ad>();
        }
    }
}
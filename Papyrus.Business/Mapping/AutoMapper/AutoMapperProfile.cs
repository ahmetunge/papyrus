using AutoMapper;
using Papyrus.Entities.Concrete;
using Papyrus.Entities.Dtos;

namespace Papyrus.Business.Mapping.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Property, PropertyForAdDto>();
            CreateMap<Category, CategoryForAdDto>();
            CreateMap<ProducPropertyValueForCreationAdDto, ProductPropertyValue>();
            CreateMap<ProductForCreationAdDto, Product>();
            CreateMap<AdForCreationDto, Ad>();

            CreateMap<Ad, MemberAdForListDto>();

            CreateMap<Ad, AdForDetailDto>()
            .ForMember(a => a.CategoryName,
            opt => opt.MapFrom(dest => dest.Category.Name));
        }
    }
}
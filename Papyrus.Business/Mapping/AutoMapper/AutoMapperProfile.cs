using AutoMapper;
using Papyrus.Entities.Concrete;
using Papyrus.Entities.Dtos;

namespace Papyrus.Business.Mapping.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<BookForCreationDto, Book>();

            CreateMap<BookForEditDto, Book>();

            CreateMap<Genre, KeyValueDto>();

            CreateMap<Catalog, CatalogToEditBookDto>();

            CreateMap<Book, BookForDetailDto>()
            .ForMember(
                dest => dest.CatalogId,
                opt => opt.MapFrom(src => src.Genre.CatalogId)
            );
        }
    }
}
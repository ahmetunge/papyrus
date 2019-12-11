using AutoMapper;
using Papyrus.Entities;
using Papyrus.Entities.Dtos;

namespace Papyrus.Business.Mapping.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<BookForCreationDto, Book>();

            CreateMap<BookForEditDto, Book>();
        }
    }
}
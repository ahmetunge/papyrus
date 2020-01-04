using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Core.Utilities.Results;
using Papyrus.Business.Abstract;
using Papyrus.DataAccess.Abstract;
using Papyrus.Entities.Dtos;

namespace Papyrus.Business.Concrete
{
    public class CatalogManager : ICatalogService
    {
        private readonly ICatalogRepository _catalogRepository;
        private readonly IMapper _mapper;
        public CatalogManager(ICatalogRepository catalogRepository, IMapper mapper)
        {
            _mapper = mapper;
            _catalogRepository = catalogRepository;

        }
        public async Task<IDataResult<List<CatalogToEditBookDto>>> GetCatalogsIncludeGenresAsync()
        {
            var catalogsFromDb = await _catalogRepository.GetCatalogsIncludeGenreAsync();

            List<CatalogToEditBookDto> catalogs = _mapper
                             .Map<List<CatalogToEditBookDto>>(catalogsFromDb);

            return new SuccessDataResult<List<CatalogToEditBookDto>>(catalogs);

        }
    }
}
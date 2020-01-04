using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Papyrus.Entities.Dtos;

namespace Papyrus.Business.Abstract
{
    public interface ICatalogService
    {
        Task<IDataResult<List<CatalogToEditBookDto>>> GetCatalogsIncludeGenresAsync();
    }
}
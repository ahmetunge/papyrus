using System.Collections.Generic;
using System.Threading.Tasks;
using Core.DataAccess;
using Papyrus.Entities.Concrete;

namespace Papyrus.DataAccess.Abstract
{
    public interface ICatalogRepository:IRepositoryBase<Catalog>
    {
        Task<List<Catalog>> GetCatalogsIncludeGenreAsync();
    }
}
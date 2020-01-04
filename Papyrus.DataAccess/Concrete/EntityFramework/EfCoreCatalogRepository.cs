using System.Collections.Generic;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Papyrus.DataAccess.Abstract;
using Papyrus.Entities.Concrete;

namespace Papyrus.DataAccess.Concrete.EntityFramework
{
    public class EfCoreCatalogRepository : EfCoreRepositoryBase<Catalog>, ICatalogRepository
    {
        private readonly PapyrusContext _context;

        public EfCoreCatalogRepository(PapyrusContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Catalog>> GetCatalogsIncludeGenreAsync()
        {
            return await _context.Catalogs.Include(c => c.Genres)
            .ToListAsync();
        }
    }
}
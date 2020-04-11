using System;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Papyrus.DataAccess.Abstract;
using Papyrus.Entities.Concrete;

namespace Papyrus.DataAccess.Concrete.EntityFramework
{
    public class EfCoreAdRepository : EfCoreRepositoryBase<Ad>, IAdRepository
    {
        private readonly PapyrusContext _context;
        public EfCoreAdRepository(PapyrusContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Ad> GetAdDetails(Guid adId)
        {
            return await _context.Ads
            .Include(a => a.Category)
            .Include(a => a.Product)
            .ThenInclude(p => p.ProductPropertyValues)
            .ThenInclude(ppv => ppv.Property)
            .SingleOrDefaultAsync(a => a.Id == adId);
        }
    }
}
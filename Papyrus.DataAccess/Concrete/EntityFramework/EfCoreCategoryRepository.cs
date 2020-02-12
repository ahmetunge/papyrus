using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Papyrus.DataAccess.Abstract;
using Papyrus.Entities.Concrete;
using Papyrus.Entities.Dtos;

namespace Papyrus.DataAccess.Concrete.EntityFramework
{
    public class EfCoreCategoryRepository : EfCoreRepositoryBase<Category>, ICategoryRepository
    {
        private readonly PapyrusContext _context;
        public EfCoreCategoryRepository(PapyrusContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetCategoriesIncludePropertiesAsync()
        {
            return await _context.Categories.Include(c => c.Properties).ToListAsync();
        }
    }
}
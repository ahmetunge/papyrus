using System;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Papyrus.DataAccess.Abstract;
using Papyrus.Entities.Concrete;

namespace Papyrus.DataAccess.Concrete.EntityFramework
{
    public class EfCoreBookRepository : EfCoreRepositoryBase<Book>, IBookRepository
    {
        private readonly PapyrusContext _context;

        public EfCoreBookRepository(PapyrusContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Book> GetByIdIncludeGenreAsync(Guid id)
        {
            var book =await _context.Books
            .Include(b => b.Genre)
            .SingleOrDefaultAsync(b => b.Id==id);

            return book;
        }
    }
}
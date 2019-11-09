using Core.DataAccess.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Papyrus.DataAccess.Abstract;
using Papyrus.Entities;

namespace Papyrus.DataAccess.Concrete.EntityFramework
{
    public class EfCoreBookRepository : EfCoreRepositoryBase<Book>, IBookRepository
    {
        public EfCoreBookRepository(PapyrusContext context) : base(context)
        {
        }
    }
}
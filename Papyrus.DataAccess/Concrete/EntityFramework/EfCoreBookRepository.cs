using Core.DataAccess.EntityFramework;
using Papyrus.DataAccess.Abstract;
using Papyrus.Entities.Concrete;

namespace Papyrus.DataAccess.Concrete.EntityFramework
{
    public class EfCoreBookRepository : EfCoreRepositoryBase<Book>, IBookRepository
    {
        public EfCoreBookRepository(PapyrusContext context) : base(context)
        {
        }
    }
}
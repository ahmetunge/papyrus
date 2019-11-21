using Papyrus.DataAccess.Abstract;

namespace Papyrus.DataAccess.Concrete.EntityFramework
{
    public class EfCoreUnitOfWork : IUnitOfWork
    {
        private readonly PapyrusContext _context;

        public EfCoreUnitOfWork(PapyrusContext context)
        {
            _context = context;
        }

        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}
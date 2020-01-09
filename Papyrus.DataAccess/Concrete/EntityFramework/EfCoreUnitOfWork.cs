using System.Threading.Tasks;
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

        public async Task CompleteAsync()
        {
           await _context.SaveChangesAsync();
        }
    }
}
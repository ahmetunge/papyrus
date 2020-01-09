using System.Threading.Tasks;

namespace Papyrus.DataAccess.Abstract
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
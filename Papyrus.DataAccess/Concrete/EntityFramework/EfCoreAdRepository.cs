using Core.DataAccess.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Papyrus.DataAccess.Abstract;
using Papyrus.Entities.Concrete;

namespace Papyrus.DataAccess.Concrete.EntityFramework
{
    public class EfCoreAdRepository : EfCoreRepositoryBase<Ad>, IAdRepository
    {
        public EfCoreAdRepository(PapyrusContext context) : base(context)
        {
        }
    }
}
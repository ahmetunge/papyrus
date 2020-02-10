using Core.DataAccess.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Papyrus.DataAccess.Abstract;
using Papyrus.Entities.Concrete;

namespace Papyrus.DataAccess.Concrete.EntityFramework
{
    public class EfCorePropertyRepository : EfCoreRepositoryBase<Property>, IPropertyRepository
    {
        public EfCorePropertyRepository(PapyrusContext context) : base(context)
        {
        }
    }
}
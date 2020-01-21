using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Papyrus.Entities.Concrete;

namespace Papyrus.Business.Abstract
{
    public interface IAdService
    {
         Task<IDataResult<List<Ad>>> GetListAsync();
    }
}
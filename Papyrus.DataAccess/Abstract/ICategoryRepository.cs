using System.Collections.Generic;
using System.Threading.Tasks;
using Core.DataAccess;
using Papyrus.Entities.Concrete;
using Papyrus.Entities.Dtos;

namespace Papyrus.DataAccess.Abstract
{
    public interface ICategoryRepository:IRepositoryBase<Category>
    {
    }
}
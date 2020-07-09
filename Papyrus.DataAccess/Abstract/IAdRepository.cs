using System;
using System.Threading.Tasks;
using Core.DataAccess;
using Papyrus.Entities.Concrete;

namespace Papyrus.DataAccess.Abstract
{
    public interface IAdRepository : IRepositoryBase<Ad>
    {
        Task<Ad> GetAdDetailsAsync(Guid adId);
    }
}
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.DataAccess;
using Core.Entities.Concrete;

namespace Papyrus.DataAccess.Abstract
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        Task<List<Role>> GetRolesAsync(Guid userId);
    }
}
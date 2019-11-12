using System;
using System.Collections.Generic;
using Core.DataAccess;
using Core.Entities.Concrete;

namespace Papyrus.DataAccess.Abstract
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        List<Role> GetUserRoles(Guid userId);
    }
}
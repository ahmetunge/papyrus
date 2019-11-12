using System;
using System.Collections.Generic;
using Core.Entities.Concrete;

namespace Papyrus.Business.Abstract
{
    public interface IUserService
    {
        List<Role> GetUserRoles(Guid userId);
        void AddUser(User user);

        User GetUserByMail(string mail);
    }
}
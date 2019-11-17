using System;
using System.Collections.Generic;
using Core.Entities.Concrete;
using Core.Utilities.Results;

namespace Papyrus.Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<Role>> GetUserRoles(Guid userId);
        IResult AddUser(User user);

        IDataResult<User> GetUserByMail(string mail);
    }
}
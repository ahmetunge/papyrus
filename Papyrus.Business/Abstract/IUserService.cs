using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities.Concrete;
using Core.Utilities.Results;

namespace Papyrus.Business.Abstract
{
    public interface IUserService
    {
        Task<IDataResult<List<Role>>> GetRolesAsync(Guid userId);
        Task<IResult> CreateAsync(User user);

        Task<IDataResult<User>> GetByMailAsync(string mail);
    }
}
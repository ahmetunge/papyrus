using System.Threading.Tasks;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security;
using Papyrus.Entities.Dtos;

namespace Papyrus.Business.Abstract
{
    public interface IAuthService
    {
       Task<IDataResult<User>> RegisterAsync(UserForRegisterDto userForRegisterDto);
        Task<IDataResult<User>> LoginAsync(UserForLoginDto userForLogin);
        Task<IResult> UserExistAsync(string email);
        Task<IDataResult<AccessToken>> CreateAccessTokenAsync(User user);

    }
}
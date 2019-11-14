using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security;
using Papyrus.Entities.Dtos;

namespace Papyrus.Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto);
        IDataResult<User> Login(UserForLoginDto userForLogin);
        IResult UserExist(string email);
        IDataResult<AccessToken> CreateAccessToken(User user);

    }
}
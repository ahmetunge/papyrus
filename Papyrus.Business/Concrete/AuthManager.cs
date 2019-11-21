using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security;
using Core.Utilities.Security.Hashing;
using Papyrus.Business.Abstract;
using Papyrus.Business.Constants;
using Papyrus.Entities.Dtos;

namespace Papyrus.Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly IUserService _userService;
        private readonly ITokenHelper _tokenHelper;
        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetUserRoles(user.Id);
            var accessToken = _tokenHelper.CreateToken(user, claims.Data);
            //TODO All data results constructurs should include data
            return new SuccessDataResult<AccessToken>(accessToken);
        }

        public IDataResult<User> Login(UserForLoginDto userForLogin)
        {
            var userToCheck = _userService.GetUserByMail(userForLogin.Email);

            if (userToCheck.Data == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }

            if (!HashingHelper.VerifyPasswordHash(userForLogin.Password, userToCheck.Data.PasswordHash, userToCheck.Data.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }

            return new SuccessDataResult<User>(userToCheck.Data, Messages.SuccessLogin);
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(userForRegisterDto.Password, out passwordHash, out passwordSalt);

            var user = new User
            {
                Email = userForRegisterDto.Email,
                Firstname = userForRegisterDto.Firstname,
                Lastname = userForRegisterDto.Lastname,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                //TO DO Refactor this code
                Status = 1
            };

            _userService.AddUser(user);

            return new SuccessDataResult<User>(user, Messages.UserRegistered);

        }

        public IResult UserExist(string email)
        {
            if (_userService.GetUserByMail(email).Data != null)
            {
                return new ErrorResult(Messages.UserAlreadyExist);
            }

            return new SuccessResult();
        }
    }
}
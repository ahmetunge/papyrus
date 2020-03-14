using System.Threading.Tasks;
using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
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

        public async Task<IDataResult<AccessToken>> CreateAccessTokenAsync(User user)
        {
            var claims =await _userService.GetRolesAsync(user.Id);
            var accessToken = _tokenHelper.CreateToken(user, claims.Data);
            //TODO All data results constructurs should include data
            return new SuccessDataResult<AccessToken>(accessToken);
        }

       [LogAspect(typeof(DatabaseLogger))]
        public async Task<IDataResult<User>> LoginAsync(UserForLoginDto userForLogin)
        {
            var userToCheck =await _userService.GetByMailAsync(userForLogin.Email);

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

        //[LogAspect(typeof(FileLogger))]
        public async Task<IDataResult<User>> RegisterAsync(UserForRegisterDto userForRegisterDto)
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

           await _userService.AddAsync(user);

            return new SuccessDataResult<User>(user, Messages.UserRegistered);

        }

        public async Task<IResult> UserExistAsync(string email)
        {
            var user = await _userService.GetByMailAsync(email);
            if (user.Data != null)
            {
                return new ErrorResult(Messages.UserAlreadyExist);
            }

            return new SuccessResult();
        }
    }
}
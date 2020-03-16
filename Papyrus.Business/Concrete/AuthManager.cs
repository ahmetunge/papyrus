using System.Net;
using System.Threading.Tasks;
using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Entities.Concrete;
using Core.Utilities.Business;
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

        [LogAspect(typeof(FileLogger))]
        public async Task<IDataResult<AccessToken>> CreateAccessTokenAsync(User user)
        {
            var claims = await _userService.GetRolesAsync(user.Id);
            var accessToken = _tokenHelper.CreateToken(user, claims.Data);
            
            return new SuccessDataResult<AccessToken>(accessToken);
        }

        [LogAspect(typeof(FileLogger))]
        public async Task<IDataResult<User>> LoginAsync(UserForLoginDto userForLogin)
        {
            var userToCheck = await _userService.GetByMailAsync(userForLogin.Email);

           IResult result=  BusinessRules.Run(userToCheck, VerifyPassword(userForLogin.Password, userToCheck.Data.PasswordHash, userToCheck.Data.PasswordSalt));

            if (result != null)
            {
                return (IDataResult<User>)result;
            }

            return new SuccessDataResult<User>(userToCheck.Data, Messages.SuccessLogin, HttpStatusCode.OK);
        }

        [LogAspect(typeof(FileLogger))]
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

            await _userService.CreateAsync(user);

            return new SuccessDataResult<User>(user, Messages.UserRegistered, HttpStatusCode.Created);

        }

        public async Task<IResult> UserExistAsync(string email)
        {
            var user = await _userService.GetByMailAsync(email);
            if (user.Data != null)
            {
                return new ErrorResult(Messages.UserAlreadyExist, HttpStatusCode.Conflict);
            }

            return new SuccessResult();
        }

        private IResult VerifyPassword(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            if (!HashingHelper.VerifyPasswordHash(password, passwordHash, passwordSalt))
            {
                return new ErrorDataResult<User>(Messages.UserNotFound, HttpStatusCode.NotFound);
            }

            return new SuccessResult();
        }
    }
}
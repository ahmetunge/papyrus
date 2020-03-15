using System.Net;
using System.Threading.Tasks;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security;
using Core.Utilities.Security.Hashing;
using Moq;
using Papyrus.Business.Abstract;
using Papyrus.Business.Concrete;
using Papyrus.Business.Constants;
using Papyrus.Entities.Dtos;
using Xunit;

namespace Papyrus.Business.Tests
{
    public class AuthManagerTests
    {
        Mock<IUserService> _mockUserService;
        Mock<ITokenHelper> _mockTokenHelper;
        public AuthManagerTests()
        {
            _mockUserService = new Mock<IUserService>();
            _mockTokenHelper = new Mock<ITokenHelper>();
        }

        [Fact]
        public async Task Login_IfUserNotFound_ShouldReturnError()
        {
            User user = new User
            {
                PasswordHash = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 },
                PasswordSalt = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 }
            };

            IDataResult<User> dataResult = new ErrorDataResult<User>(user, Messages.UserNotFound, HttpStatusCode.NotFound);

            _mockUserService.Setup(s => s.GetByMailAsync("ahmetunge@gmail.com"))
            .ReturnsAsync(dataResult);

            AuthManager authManager = new AuthManager(_mockUserService.Object, _mockTokenHelper.Object);

            var result = await authManager.LoginAsync(new UserForLoginDto
            {
                Email = "ahmetunge@gmail.com",
                Password = "password"
            });

            Assert.False(result.Success);
            Assert.Equal(Messages.UserNotFound, result.Message);

        }

        [Fact]
        public async Task Login_IfPasswordWrong_ShouldReturnError()
        {
            User user = new User
            {
                PasswordHash = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 },
                PasswordSalt = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 }
            };

            IDataResult<User> dataResult = new SuccessDataResult<User>(user);

            _mockUserService.Setup(s => s.GetByMailAsync("ahmetunge@gmail.com"))
            .ReturnsAsync(dataResult);

            AuthManager authManager = new AuthManager(_mockUserService.Object, _mockTokenHelper.Object);

            var result = await authManager.LoginAsync(new UserForLoginDto
            {
                Email = "ahmetunge@gmail.com",
                Password = "password"
            });

            Assert.False(result.Success);
            Assert.Equal(Messages.UserNotFound, result.Message);


        }

        [Fact]
        public async Task UserExist_IfUserAlreadyExist_ShouldReturnError()
        {
            User user = new User();
            IDataResult<User> dataResult = new SuccessDataResult<User>(user);

            _mockUserService.Setup(s => s.GetByMailAsync("ahmetunge@gmail.com"))
            .ReturnsAsync(dataResult);

            AuthManager authManager = new AuthManager(_mockUserService.Object, _mockTokenHelper.Object);

            var result = await authManager.UserExistAsync("ahmetunge@gmail.com");

            Assert.False(result.Success);
            Assert.Equal(Messages.UserAlreadyExist, result.Message);

        }

        [Fact]
        public async Task UserExist_IfUserNotExist_ShouldReturnSuccessResult()
        {

            User user = null;
            IDataResult<User> dataResult = new SuccessDataResult<User>(user);

            _mockUserService.Setup(s => s.GetByMailAsync("ahmetunge@gmail.com"))
           .ReturnsAsync(dataResult);

            AuthManager authManager = new AuthManager(_mockUserService.Object, _mockTokenHelper.Object);

            var result = await authManager.UserExistAsync("ahmetunge@gmail.com");

            Assert.True(result.Success);
        }
    }
}
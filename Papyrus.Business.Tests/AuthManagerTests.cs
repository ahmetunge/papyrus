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
        Mock<IUserService> _mockService;
        Mock<ITokenHelper> _mockTokenHelper;
        public AuthManagerTests()
        {
            _mockService = new Mock<IUserService>();
            _mockTokenHelper = new Mock<ITokenHelper>();
        }

        [Fact]
        public void Login_IfUserNotFound_ShouldReturnError()
        {

            _mockService.Setup(s => s.GetUserByMail("ahmetunge@gmail.com").Data)
            .Returns<User>(null);

            AuthManager authManager = new AuthManager(_mockService.Object, _mockTokenHelper.Object);

            var result = authManager.Login(new UserForLoginDto
            {
                Email = "ahmetunge@gmail.com",
                Password = "password"
            });

            Assert.False(result.Success);
            Assert.Equal(Messages.UserNotFound, result.Message);

        }

        [Fact]
        public void Login_IfPasswordWrong_ShouldReturnError()
        {

            _mockService.Setup(s => s.GetUserByMail("ahmetunge@gmail.com").Data)
            .Returns(new User
            {
                PasswordHash = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 },
                PasswordSalt = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 }
            });

            AuthManager authManager = new AuthManager(_mockService.Object, _mockTokenHelper.Object);

            var result = authManager.Login(new UserForLoginDto
            {
                Email = "ahmetunge@gmail.com",
                Password = "password"
            });

            Assert.False(result.Success);
            Assert.Equal(Messages.UserNotFound, result.Message);


        }

        [Fact]
        public void UserExist_IfUserAlreadyExist_ShouldReturnError()
        {
            _mockService.Setup(s => s.GetUserByMail("ahmetunge@gmail.com").Data)
            .Returns(new User());

            AuthManager authManager = new AuthManager(_mockService.Object, _mockTokenHelper.Object);

            var result = authManager.UserExist("ahmetunge@gmail.com");

            Assert.False(result.Success);
            Assert.Equal(Messages.UserAlreadyExist, result.Message);

        }

        [Fact]
        public void UserExist_IfUserNotExist_ShouldReturnSuccessResult()
        {

            _mockService.Setup(s => s.GetUserByMail("ahmetunge@gmail.com").Data)
           .Returns<User>(null);

            AuthManager authManager = new AuthManager(_mockService.Object, _mockTokenHelper.Object);

            var result = authManager.UserExist("ahmetunge@gmail.com");

            Assert.True(result.Success);
        }
    }
}
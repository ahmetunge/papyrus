using System;
using System.Collections.Generic;
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
        public async Task CreateAccessTokenAsync_IfCorrect_ShouldReturSuccessResult()
        {
            Guid userId = new Guid();

            User user = new User
            {
                Id = userId
            };

            IDataResult<List<Role>> claims = new SuccessDataResult<List<Role>>(new List<Role> { 
            new Role
            {
                Name="Test Name 1"
            }
            });

            AccessToken accessToken = new AccessToken
            {
                Token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6ImFobWV0dW5nZUBvdXRsb29rLmNvbSIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL25hbWUiOiJBaG1ldCDDnG5nZSIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL25hbWVpZGVudGlmaWVyIjoiY2Q3NDQ3MGMtNGNlNy00ODE3LWJjZTYtZmY5YzMxZDM2Y2Y0IiwiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS93cy8yMDA4LzA2L2lkZW50aXR5L2NsYWltcy9yb2xlIjoiQWRtaW4iLCJuYmYiOjE1ODQyNzY4MjIsImV4cCI6MTU4NDI3NzQyMiwiaXNzIjoid3d3LmFobWV0dW5nZS5jb20iLCJhdWQiOiJ3d3cuYWhtZXR1bmdlLmNvbSJ9.FeWXYaH4_1YrCW2jz3HqyDS4lD3FGNoDHk5M0e-LgnQ",
                Expiration = new DateTime(1907, 10, 20)

            };

            _mockUserService.Setup(s => s.GetRolesAsync(It.IsAny<Guid>()))
         .ReturnsAsync(claims);

            _mockTokenHelper.Setup(th => th.CreateToken(It.IsAny<User>(),It.IsAny<List<Role>>()))
            .Returns(accessToken);


            AuthManager authManager = new AuthManager(_mockUserService.Object, _mockTokenHelper.Object);


            IDataResult<AccessToken> result = await authManager.CreateAccessTokenAsync(user);

            Assert.True(result.Success);

            Assert.Equal(accessToken.Token, result.Data.Token);
            Assert.Equal(accessToken.Expiration, result.Data.Expiration);

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
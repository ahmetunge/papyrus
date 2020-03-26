using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Moq;
using Papyrus.Business.Concrete;
using Papyrus.Business.Constants;
using Papyrus.DataAccess.Abstract;
using Xunit;

namespace Papyrus.Business.Tests
{

    public class UserManagerTests
    {
        private readonly Mock<IUserRepository> _mockRepository;
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        public UserManagerTests()
        {
            _mockRepository = new Mock<IUserRepository>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();
        }
        [Fact]
        public async Task CreateUser_WhenUserIsNull_ShouldReturnFalse()
        {

            UserManager userManager = new UserManager(_mockRepository.Object, _mockUnitOfWork.Object);
            User user = new User();
            var result = await userManager.CreateAsync(null);

            Assert.False(result.Success);

        }

        [Fact]
        public async Task CreateUser_WhenUserCreateed_ShouldReturnSuccessAndData()
        {
            UserManager userManager = new UserManager(_mockRepository.Object, _mockUnitOfWork.Object); ;
            var user = new User
            {
                Firstname = "Ahmet",
                Lastname = "Ünge",
                Email = "ahmetunge@gmail.com",
                Status = 1,
                PasswordSalt = null,
                PasswordHash = null
            };

            var result = await userManager.CreateAsync(user);
            Assert.True(result.Success);
            Assert.Equal(result.Message, Messages.UserAddedSuccessfully);
        }

        [Theory, InlineData(new object[] { "ahmetunge@gmail.com" })]
        public async Task GetUserByMail_IfUserNotFound_ShouldReturnErrorResult(string mail)
        {
            User user = null;
            _mockRepository.Setup(x => x.FindAsync(It.IsAny<Expression<Func<User, bool>>>()))
            .ReturnsAsync(user);

            UserManager userManager = new UserManager(_mockRepository.Object, _mockUnitOfWork.Object);
            var result = await userManager.GetByMailAsync(mail);

            Assert.False(result.Success);
            Assert.Equal(result.Message, Messages.UserNotFound);

        }

        [Theory, InlineData(new object[] { "ahmetunge@gmail.com" })]
        public async Task GetUserByMail_IfUserExist_ShouldReturnSuccessResult(string mail)
        {
            _mockRepository.Setup(x => x.FindAsync(It.IsAny<Expression<Func<User, bool>>>()))
            .ReturnsAsync(new User
            {
                Id = new Guid(),
                Firstname = "Ahmet",
                Lastname = "Unge",
                Email = "ahmetunge@gmail.com",
                Status = 1,
            });

            UserManager userManager = new UserManager(_mockRepository.Object, _mockUnitOfWork.Object); ;
            var result = await userManager.GetByMailAsync(mail);

            Assert.True(result.Success);

        }

        [Theory, InlineData("ahmetunge@gmail.com")]
        public async Task GetUserByMail_IfMailValid_ShouldReturnSuccessResult(string mail)
        {
            _mockRepository.Setup(x => x.FindAsync(It.IsAny<Expression<Func<User, bool>>>()))
           .ReturnsAsync(new User
           {
               Id = new Guid(),
               Firstname = "Ahmet",
               Lastname = "Unge",
               Email = "ahmetunge@gmail.com",
               Status = 1,
           });

            UserManager userManager = new UserManager(_mockRepository.Object, _mockUnitOfWork.Object); ;
            var result = await userManager.GetByMailAsync(mail);

            Assert.True(result.Success);
        }


        [Theory]
        [InlineData("ahmetunge")]
        [InlineData("")]
        public async Task GetUserByMail_IfMailInvalid_ShouldReturnErrorResult(string mail)
        {
            UserManager userManager = new UserManager(_mockRepository.Object, _mockUnitOfWork.Object); ;
            var result = await userManager.GetByMailAsync(mail);

            Assert.False(result.Success);
            Assert.Equal(result.Message, Messages.InvalidMail);
        }

        [Fact]
        public async Task GetRolesAsync_IfSuccess_ShouldResturnSuccesResult()
        {

            List<Role> roles = new List<Role>{
            new Role
            {
                Name="Admin",
            },
            new Role
            {
                Name="Member"
            }
            };
            _mockRepository.Setup(s => s.GetRolesAsync(It.IsAny<Guid>()))
            .ReturnsAsync(roles);

            UserManager userManager = new UserManager(_mockRepository.Object, _mockUnitOfWork.Object);

            var result = await userManager.GetRolesAsync(Guid.NewGuid());

            Assert.True(result.Data.Count== 2);
            Assert.True(result.Success);

        }

    }
}
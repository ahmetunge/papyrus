using System;
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
        public async Task CreateUser_ShouldReturnFalse_WhenUserIsNull()
        {

            UserManager userManager = new UserManager(_mockRepository.Object, _mockUnitOfWork.Object);
            User user = new User();
            var result =await userManager.CreateAsync(null);

            Assert.False(result.Success);

        }

        [Fact]
        public async Task CreateUser_ShouldReturnSuccessAndData_WhenUserCreateed()
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

            var result =await userManager.CreateAsync(user);
            Assert.True(result.Success);
            Assert.Equal(result.Message, Messages.UserAddedSuccessfully);
        }

        [Theory, InlineData(new object[] { "ahmetunge@gmail.com" })]
        public async Task GetUserByMail_ShouldReturnErrorResult_IfUserNotFound(string mail)
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
        public async Task GetUserByMail_ShouldReturnSuccessResult_IfUserExist(string mail)
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
            var result =await userManager.GetByMailAsync(mail);

            Assert.True(result.Success);

        }

        [Theory, InlineData("ahmetunge@gmail.com")]
        public async Task GetUserByMail_ShouldReturnSuccessResult_IfMailValid(string mail)
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
            var result =await userManager.GetByMailAsync(mail);

            Assert.True(result.Success);
        }


        [Theory]
        [InlineData("ahmetunge")]
        [InlineData("")]
        public async Task GetUserByMail_ShouldReturnErrorResult_IfMailInvalid(string mail)
        {
            UserManager userManager = new UserManager(_mockRepository.Object, _mockUnitOfWork.Object); ;
            var result =await userManager.GetByMailAsync(mail);

            Assert.False(result.Success);
            Assert.Equal(result.Message, Messages.InvalidMail);
        }



    }
}
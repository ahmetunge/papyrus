using System;
using System.Linq.Expressions;
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
        public void AddUser_ShouldReturnFalse_WhenUserIsNull()
        {

            UserManager userManager = new UserManager(_mockRepository.Object, _mockUnitOfWork.Object);
            User user = new User();
            var result = userManager.AddUser(null);

            Assert.False(result.Success);

        }

        [Fact]
        public void AddUser_ShouldReturnSuccessAndData_WhenUserAdded()
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

            var result = userManager.AddUser(user);
            Assert.True(result.Success);
            Assert.Equal(result.Message, Messages.UserAddedSuccessfully);
        }

        [Theory, InlineData(new object[] { "ahmetunge@gmail.com" })]
        public void GetUserByMail_ShouldReturnErrorResult_IfUserNotFound(string mail)
        {
            _mockRepository.Setup(x => x.Find(It.IsAny<Expression<Func<User, bool>>>()))
            .Returns<User>(null);

            UserManager userManager = new UserManager(_mockRepository.Object, _mockUnitOfWork.Object); ;
            var result = userManager.GetUserByMail(mail);

            Assert.False(result.Success);
            Assert.Equal(result.Message, Messages.UserNotFound);

        }

        [Theory, InlineData(new object[] { "ahmetunge@gmail.com" })]
        public void GetUserByMail_ShouldReturnSuccessResult_IfUserExist(string mail)
        {
            _mockRepository.Setup(x => x.Find(It.IsAny<Expression<Func<User, bool>>>()))
            .Returns(new User
            {
                Id = new Guid(),
                Firstname = "Ahmet",
                Lastname = "Unge",
                Email = "ahmetunge@gmail.com",
                Status = 1,
            });

            UserManager userManager = new UserManager(_mockRepository.Object, _mockUnitOfWork.Object); ;
            var result = userManager.GetUserByMail(mail);

            Assert.True(result.Success);

        }

        [Theory, InlineData("ahmetunge@gmail.com")]
        public void GetUserByMail_ShouldReturnSuccessResult_IfMailValid(string mail)
        {
            _mockRepository.Setup(x => x.Find(It.IsAny<Expression<Func<User, bool>>>()))
           .Returns(new User
           {
               Id = new Guid(),
               Firstname = "Ahmet",
               Lastname = "Unge",
               Email = "ahmetunge@gmail.com",
               Status = 1,
           });

            UserManager userManager = new UserManager(_mockRepository.Object, _mockUnitOfWork.Object); ;
            var result = userManager.GetUserByMail(mail);

            Assert.True(result.Success);
        }


        [Theory]
        [InlineData("ahmetunge")]
        [InlineData("")]
        public void GetUserByMail_ShouldReturnErrorResult_IfMailInvalid(string mail)
        {
            UserManager userManager = new UserManager(_mockRepository.Object, _mockUnitOfWork.Object); ;
            var result = userManager.GetUserByMail(mail);

            Assert.False(result.Success);
            Assert.Equal(result.Message, Messages.InvalidMail);
        }



    }
}
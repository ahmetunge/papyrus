using FluentValidation.TestHelper;
using Papyrus.Business.Constants;
using Papyrus.Business.Validations.FluentValidation;
using Papyrus.Entities.Dtos;
using Xunit;

namespace Papyrus.Business.Tests
{
    public class UserForLoginValidatorTests
    {
        private UserForLoginDtoValidator _userForLoginDtoValidator;
        public UserForLoginValidatorTests()
        {
            _userForLoginDtoValidator = new UserForLoginDtoValidator();
        }


        // [Fact]
        // public void UserForForLogin_WhenEmailIsNull_ShouldHaveError()
        // {
        //     UserForLoginDto user = new UserForLoginDto();

        //     var result = _userForLoginDtoValidator.TestValidate(user);

        //     result.ShouldHaveValidationErrorFor(u => u.Email)
        //     .WithErrorMessage(Messages.EmailRequired);

        // }

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData(null)]
        public void UserForForLogin_WhenEmailIsNullOrEmptyOrWhiteSpace_ShouldHaveError(string email)
        {
            UserForLoginDto user = new UserForLoginDto()
            {
                Email = email
            };

            var result = _userForLoginDtoValidator.TestValidate(user);

            result.ShouldHaveValidationErrorFor(u => u.Email)
            .WithErrorMessage(Messages.EmailRequired);


        }


        [Theory]
        [InlineData("test")]
        [InlineData("test@gmail")]
        [InlineData("test.com")]
        public void UserForForLogin_WhenEmailIsInvalid_ShouldHaveError(string mail)
        {
            UserForLoginDto user = new UserForLoginDto
            {
                Email = mail
            };

            var result = _userForLoginDtoValidator.TestValidate(user);

            result.ShouldHaveValidationErrorFor(u => u.Email)
            .WithErrorMessage(Messages.InvalidMail);
        }



        // [Fact]
        // public void UserForForLogin_WhenPasswordIsNull_ShouldHaveError()
        // {
        //     UserForLoginDto user = new UserForLoginDto();

        //     var result = _userForLoginDtoValidator.TestValidate(user);

        //     result.ShouldHaveValidationErrorFor(u => u.Password)
        //     .WithErrorMessage(Messages.PasswordRequired);

        // }

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData(null)]
        public void UserForForLogin_WhenPasswordEmptyOrWhitespace_ShouldHaveError(string password)
        {
            UserForLoginDto user = new UserForLoginDto
            {
                Password = password
            };

            var result = _userForLoginDtoValidator.TestValidate(user);

            result.ShouldHaveValidationErrorFor(u => u.Password)
            .WithErrorMessage(Messages.PasswordRequired);

        }


        [Theory]
        [InlineData("test@test.com")]
        public void UserForForLogin_WhenEmailIsValid_ShouldNotHaveError(string mail)
        {
            UserForLoginDto user = new UserForLoginDto
            {
                Email = mail
            };

            var result = _userForLoginDtoValidator.TestValidate(user);

            result.ShouldNotHaveValidationErrorFor(u => u.Email);

        }

        [Theory]
        [InlineData("1907")]
        public void UserForForLogin_WhenPasswordIsSpecified_ShouldNotHaveError(string password)
        {
            UserForLoginDto user = new UserForLoginDto
            {
                Password = password
            };

            var result = _userForLoginDtoValidator.TestValidate(user);

            result.ShouldNotHaveValidationErrorFor(u => u.Password);
        }

        [Fact]
        public void UserForForLogin_WhenUserIsSpecified_ShouldNotHaveError()
        {
            UserForLoginDto user = new UserForLoginDto
            {
                Email = "test@gmail.com",
                Password = "1907"
            };

            var result = _userForLoginDtoValidator.TestValidate(user);

            result.ShouldNotHaveAnyValidationErrors();
        }


    }
}
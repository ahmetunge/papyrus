using FluentValidation.TestHelper;
using Papyrus.Business.Constants;
using Papyrus.Business.Validations.FluentValidation;
using Papyrus.Entities.Dtos;
using Xunit;

namespace Papyrus.Business.Tests
{
    public class BookValidatorTests
    {
        // private BookForCreationDtoValidator _bookForCreationValidator;
        // public BookValidatorTests()
        // {
        //     _bookForCreationValidator = new BookForCreationDtoValidator();
        // }
        // [Fact]
        // public void BookValidator_WhenNameIsNull_ShouldHaveError()
        // {
        //     var bookForCreation = new BookForCreationDto();

        //     var result = _bookForCreationValidator
        //     .TestValidate(bookForCreation);

        //     result.ShouldHaveValidationErrorFor(p => p.Name)
        //     .WithErrorMessage(Messages.BookRequired);
        // }

        // [Fact]
        // public void BookValidator_WhenNameIsSpecified_ShouldNotHaveError()
        // {
        //     var bookForCreation = new BookForCreationDto
        //     {
        //         Name = "1984"
        //     };

        //     var result = _bookForCreationValidator.TestValidate(bookForCreation);

        //     result.ShouldNotHaveValidationErrorFor(p => p.Name);

        // }

        // [Fact]
        // public void BookValidator_WhenNameIsEmpty_ShouldHaveError()
        // {
        //     var bookForCreation = new BookForCreationDto
        //     {
        //         Name = ""
        //     };

        //     var result = _bookForCreationValidator.TestValidate(bookForCreation);

        //     result.ShouldHaveValidationErrorFor(p => p.Name)
        //     .WithErrorMessage(Messages.BookRequired);
        // }
    }
}
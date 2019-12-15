using FluentValidation;
using Papyrus.Business.Constants;
using Papyrus.Entities;
using Papyrus.Entities.Dtos;

namespace Papyrus.Business.Validations.FluentValidation
{
    public class BookForCreationDtoValidator : AbstractValidator<BookForCreationDto>
    {
        public BookForCreationDtoValidator()
        {
            RuleFor(b => b.Name)
            .NotEmpty()
            .WithMessage(Messages.BookRequired);
        }
    }
}
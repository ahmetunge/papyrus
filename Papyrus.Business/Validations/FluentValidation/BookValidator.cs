using FluentValidation;
using Papyrus.Entities;

namespace Papyrus.Business.Validations.FluentValidation
{
    public class BookValidator : AbstractValidator<Book>
    {
        public BookValidator()
        {
            RuleFor(b => b.Name).NotEmpty();
        }
    }
}
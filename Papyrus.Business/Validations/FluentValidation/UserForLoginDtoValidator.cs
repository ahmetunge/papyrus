using FluentValidation;
using Papyrus.Business.Constants;
using Papyrus.Entities.Dtos;

namespace Papyrus.Business.Validations.FluentValidation
{
    public class UserForLoginDtoValidator : AbstractValidator<UserForLoginDto>
    {
        public UserForLoginDtoValidator()
        {
            RuleFor(u => u.Email)
            .NotEmpty().WithMessage(Messages.EmailRequired)
            .EmailAddress().WithMessage(Messages.InvalidMail);

            RuleFor(u => u.Password)
            .NotEmpty().WithMessage(Messages.PasswordRequired);
        }
    }
}
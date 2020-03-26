using FluentValidation;
using Papyrus.Business.Constants;
using Papyrus.Entities.Dtos;

namespace Papyrus.Business.Validations.FluentValidation
{
    public class AdForCreationValidator : AbstractValidator<AdForCreationDto>
    {
        public AdForCreationValidator()
        {
            RuleFor(a => a)
            .NotNull()
            .WithMessage(Messages.AdRequired);

            RuleFor(a => a.CategoryId)
            .NotEmpty().WithMessage(Messages.CategoryRequired);

            RuleFor(a => a.Title)
            .NotEmpty()
            .WithMessage(Messages.TitleRequired);
        }
    }
}
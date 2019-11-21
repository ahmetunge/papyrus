using FluentValidation;

namespace Core.CrossCuttingConcerns.Validation.FluentValidation
{
    public static class FluentValidationTool
    {
        public static void Validate(IValidator validator, object entity)
        {

            var result = validator.Validate(entity);

            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }

        }
    }
}
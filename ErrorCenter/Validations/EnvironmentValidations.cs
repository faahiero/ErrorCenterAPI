using ErrorCenter.Models.Environment;
using FluentValidation;

namespace ErrorCenter.Validations
{
    public class EnvironmentValidations : AbstractValidator<EnvironmentModel>
    {
        public EnvironmentValidations()
        {
            RuleFor(env => env.Name)
                .NotNull()
                .WithMessage("Name can't be null");
        }
    }
}
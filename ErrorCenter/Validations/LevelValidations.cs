using ErrorCenter.Models.Level;
using FluentValidation;

namespace ErrorCenter.Validations
{
    public class LevelValidations : AbstractValidator<LevelModel>
    {
        public LevelValidations()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .WithMessage("Name can't be null");
        }
    }
}
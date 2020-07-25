using ErrorCenter.Models.Error;
using FluentValidation;

namespace ErrorCenter.Validations
{
    public class ErrorValidations : AbstractValidator<ErrorModel>
    {
        public ErrorValidations()
        {
            RuleFor(error => error.Title)
                .NotNull()
                .WithMessage("Title can't be null");
            
            RuleFor(error => error.Origin)
                .NotNull()
                .WithMessage("Origin can't be null");
            
            RuleFor(error => error.Details)
                .NotNull()
                .WithMessage("Details can't be null");

            RuleFor(error => error.EventId)
                .NotEmpty()
                .WithMessage("EventId can't be null");
            
            RuleFor(error => error.EnvironmentId)
                .NotEmpty()
                .WithMessage("EnvironmentId can't be null");
            
            RuleFor(error => error.LevelId)
                .NotEmpty()
                .WithMessage("LevelId can't be null");
        }
    }
}
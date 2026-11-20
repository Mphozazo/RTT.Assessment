using FluentValidation;

namespace RTT.Assessment.Application.Features.Person.Commands.CreatePerson
{
    public class CreatePersonCommandValidator : AbstractValidator<CreatePersonCommand>
    {
        public CreatePersonCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");
            RuleFor(p => p.Surname)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");
            RuleFor(p => p.Age)
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0.");
            RuleFor(p => p.DOB)
                .LessThan(DateOnly.FromDateTime(DateTime.Now)).WithMessage("{PropertyName} must be a date in the past.");
        }

    }
}

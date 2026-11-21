using FluentValidation;
using RTT.Assessment.Application.Contracts.Persistence;
using RTT.Assessment.Application.Features.Contact.Commands.CreateContact;

namespace RTT.Assessment.Application.Features.Contact.Shared;

public class CreateBaseContactCommandValidator : AbstractValidator<BaseContactCommand>
{
    private readonly IPersonRepository _personRepository;

    public CreateBaseContactCommandValidator()
    {


        RuleFor(p => p.PersonId)
            .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0.");
         
        RuleFor(p => p.Email)
            .EmailAddress().WithMessage("{PropertyName} must be a valid email address.")
            .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

        RuleFor(p => p.PhoneNumber)
            .Matches(@"^\+?\d{10,15}$").WithMessage("{PropertyName} must be a valid phone number.")
            .MaximumLength(15).WithMessage("{PropertyName} must not exceed 15 characters.");

        RuleFor(p => p.CellNumber)
            .Matches(@"^\+?\d{10,15}$").WithMessage("{PropertyName} must be a valid cell number.")
            .MaximumLength(15).WithMessage("{PropertyName} must not exceed 15 characters.");

    }

}


using FluentValidation;
using RTT.Assessment.Application.Contracts.Persistence;
using RTT.Assessment.Application.Features.Contact.Commands.CreateContact;

namespace RTT.Assessment.Application.Features.Contact.Commands.Shared;

public class CreateBaseContactCommandValidator : AbstractValidator<CreateContactCommand>
{
    private readonly IPersonRepository _personRepository;

    public CreateBaseContactCommandValidator(IPersonRepository personRepository)
    {
        _personRepository = personRepository;

        RuleFor(p => p.Email)
            .EmailAddress().WithMessage("{PropertyName} must be a valid email address.")
            .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");
        RuleFor(p => p.PhoneNumber)
            .Matches(@"^\+?\d{10,15}$").WithMessage("{PropertyName} must be a valid phone number.")
            .MaximumLength(10).WithMessage("{PropertyName} must not exceed 10 characters.");
        RuleFor(p => p.CellNumber)
            .Matches(@"^\+?\d{10,15}$").WithMessage("{PropertyName} must be a valid cell number.")
            .MaximumLength(10).WithMessage("{PropertyName} must not exceed 10 characters.");
        RuleFor(p => p.PersonId)
            .GreaterThan(0)
            .MustAsync(async (id, token) =>
            {
                var personExists = await _personRepository.PersonExistsAsync(id, token);
                return personExists;
            })
            .WithMessage("{PropertyName} must be a valid person");
    }

}


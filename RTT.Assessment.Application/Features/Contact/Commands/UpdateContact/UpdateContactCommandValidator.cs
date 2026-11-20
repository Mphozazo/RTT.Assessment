using FluentValidation;
using RTT.Assessment.Application.Contracts.Persistence;
using RTT.Assessment.Application.Features.Contact.Commands.Shared;

namespace RTT.Assessment.Application.Features.Contact.Commands.UpdateContact
{
    public class UpdateContactCommandValidator : AbstractValidator<UpdateContactCommand>
    {
        //Todo: repeating code need to be fixed with "Include" the base CreateBaseContactCommandValidator"
        public UpdateContactCommandValidator()
        {
            RuleFor(command => command.Id)
                .GreaterThan(0);

            RuleFor(command => command.Email)
                .EmailAddress().WithMessage("{PropertyName} must be a valid email address.")
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

            RuleFor(command => command.PhoneNumber)
                .Matches(@"^\+?\d{10,15}$").WithMessage("{PropertyName} must be a valid phone number.")
                .MaximumLength(10).WithMessage("{PropertyName} must not exceed 10 characters.");

            RuleFor(command => command.CellNumber)
                .Matches(@"^\+?\d{10,15}$").WithMessage("{PropertyName} must be a valid cell number.")
                .MaximumLength(10).WithMessage("{PropertyName} must not exceed 10 characters.");
        }
    }
}

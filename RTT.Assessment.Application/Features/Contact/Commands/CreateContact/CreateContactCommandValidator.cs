using FluentValidation;
using RTT.Assessment.Application.Contracts.Persistence;
using RTT.Assessment.Application.Features.Contact.Shared;


namespace RTT.Assessment.Application.Features.Contact.Commands.CreateContact
{
    public class CreateContactCommandValidator : AbstractValidator<BaseContactCommand>
    {
        public CreateContactCommandValidator(IPersonRepository personRepository)
        {
            Include(new CreateBaseContactCommandValidator());
        }
    }
}

using FluentValidation;
using RTT.Assessment.Application.Contracts.Persistence;
using RTT.Assessment.Application.Features.Contact.Shared;

namespace RTT.Assessment.Application.Features.Contact.Commands.UpdateContact
{
    public class UpdateContactCommandValidator : AbstractValidator<UpdateContactCommand>
    {
        public UpdateContactCommandValidator(IPersonRepository personRepository)
        {
             Include(new CreateBaseContactCommandValidator());
         

        }
    }
}

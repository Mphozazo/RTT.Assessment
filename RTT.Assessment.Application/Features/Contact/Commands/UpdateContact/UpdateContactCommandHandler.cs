using MediatR;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using RTT.Assessment.Application.Contracts.Persistence;
using RTT.Assessment.Application.Exceptions;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text;

namespace RTT.Assessment.Application.Features.Contact.Commands.UpdateContact
{
    public class UpdateContactCommandHandler : IRequestHandler<UpdateContactCommand, Unit>
    {
        private readonly IContactRepository _contactRepository;
        private readonly IPersonRepository _personRepository;

        public UpdateContactCommandHandler(IContactRepository contactRepository, IPersonRepository personRepository)
        {
            _contactRepository = contactRepository;
            _personRepository = personRepository;
        }

        public async Task<Unit> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // get existing contact from the repository
                var existingContact = await _contactRepository.GetByIdAsync(request.Id, cancellationToken);
                request.DateCreated = existingContact.DateCreated.Value;
                request.DateUpdated = DateTime.UtcNow;
                request.PersonId = existingContact.PersonId;

                var validationResult = await new UpdateContactCommandValidator(_personRepository).ValidateAsync(request, cancellationToken);
                if (validationResult.Errors.Any())
                    throw new BadRequestException("Update Contact failed", validationResult);

                // Map the request to the Contact entity
                var contact = new Domain.Contact
                {
                    Id = request.Id,
                    PersonId = request.PersonId,
                    Email = request.Email,
                    PhoneNumber = request.PhoneNumber,
                    CellNumber = request.CellNumber,
                    DateCreated = request.DateCreated,
                    DateUpdated = request.DateUpdated
                };

                await _contactRepository.UpdateAsync(contact, cancellationToken);

                return Unit.Value;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error occurred while handling UpdateContactCommand");
                throw;
            }
           

        }
    }
}

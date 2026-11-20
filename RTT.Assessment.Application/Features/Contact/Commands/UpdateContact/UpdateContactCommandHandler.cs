using MediatR;
using RTT.Assessment.Application.Contracts.Persistence;
using RTT.Assessment.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace RTT.Assessment.Application.Features.Contact.Commands.UpdateContact
{
    public class UpdateContactCommandHandler : IRequestHandler<UpdateContactCommand, Unit>
    {
        private readonly IContactRepository _contactRepository;

        public UpdateContactCommandHandler(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<Unit> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await new UpdateContactCommandValidator().ValidateAsync(request, cancellationToken);
            if (validationResult.Errors.Any())
                throw new BadRequestException("Update Contact failed", validationResult);
           
            var contact = await _contactRepository.GetByIdAsync(request.Id, cancellationToken);

            await _contactRepository.UpdateAsync(contact, cancellationToken);

            return Unit.Value;

        }
    }
}

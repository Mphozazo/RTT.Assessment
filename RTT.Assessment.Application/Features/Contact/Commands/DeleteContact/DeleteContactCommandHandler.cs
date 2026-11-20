using MediatR;
using RTT.Assessment.Application.Contracts.Persistence;
using RTT.Assessment.Application.Exceptions;

namespace RTT.Assessment.Application.Features.Contact.Commands.DeleteContact
{
    public class DeleteContactCommandHandler : IRequestHandler<DeleteContactCommand, Unit>
    {
        private readonly IContactRepository _contactRepository;

        public DeleteContactCommandHandler(IContactRepository contactRepository )
        {
            _contactRepository = contactRepository;

        }
        public async Task<Unit> Handle(DeleteContactCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var contact = await _contactRepository.GetByIdAsync(request.Id, cancellationToken);
                if (contact == null)
                    throw new NotFoundException(nameof(Domain.Contact), request.Id);

                await _contactRepository.DeleteAsync(contact, cancellationToken);
                return Unit.Value;
            }
            catch (Exception ex)
            {
                // log the error on error log 
                
                throw;
            }


        }
    }
}

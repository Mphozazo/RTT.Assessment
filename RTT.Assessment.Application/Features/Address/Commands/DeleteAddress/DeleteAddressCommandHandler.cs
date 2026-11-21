using MediatR;
using RTT.Assessment.Application.Contracts.Persistence;
using RTT.Assessment.Application.Exceptions;

namespace RTT.Assessment.Application.Features.Address.Commands.DeleteAddress
{
    public class DeleteAddressCommandHandler : IRequestHandler<DeleteAddressCommand, Unit>
    {
        private readonly IAddressRepository _addressRepository;

        public DeleteAddressCommandHandler(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }
        public async Task<Unit> Handle(DeleteAddressCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var address = await _addressRepository.GetByIdAsync(request.Id, cancellationToken);
                if (address == null)
                    throw new NotFoundException($"Address with Id {request.Id} not found.");

                await _addressRepository.DeleteAsync(address, cancellationToken);
                return Unit.Value;
            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
}

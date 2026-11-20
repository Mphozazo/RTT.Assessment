using MediatR;
using RTT.Assessment.Application.Contracts.Persistence;
using RTT.Assessment.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

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
            var address = await _addressRepository.GetByIdAsync(request.Id, cancellationToken);
            if (address == null)
                throw new NotFoundException($"Address with Id {request.Id} not found.");

            await _addressRepository.DeleteAsync(address, cancellationToken);
            return Unit.Value;
        }
    }
}

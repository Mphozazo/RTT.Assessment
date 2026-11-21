using AutoMapper;
using MediatR;
using RTT.Assessment.Application.Contracts.Persistence;
using RTT.Assessment.Application.Exceptions;
using RTT.Assessment.Application.Features.Address.Queries;
using Serilog;

namespace RTT.Assessment.Application.Features.Address.Commands.UpdateAddress
{
    public class UpdateAddressCommandHandler : IRequestHandler<UpdateAddressCommand, AddressDto>
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;

        public UpdateAddressCommandHandler(IAddressRepository addressRepository , IMapper mapper)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
        }
        public async Task<AddressDto> Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var validator = new UpdateAddressCommandValidator();
                var validationResult = validator.Validate(request);
                if (!validationResult.IsValid)
                    throw new BadRequestException("Address validation failed", validationResult);

                //make sure the address exists before updating
                var existingAddress = await _addressRepository.GetByIdAsync(request.Id, cancellationToken);
                if (existingAddress == null)
                    throw new NotFoundException($"Address with Id {request.Id} not found");

                // set dates from exsisting address to the request object to avoid overwriting them
               
                request.DateCreated = existingAddress.DateCreated;  
                request.DateUpdated = DateTime.UtcNow; 
                request.PersonId = existingAddress.PersonId; 

                // Map the request to the Address entity
                var addressEntity = _mapper.Map<Domain.Address>(request);
                // Update the address in the repository
                var updatedAddress = _addressRepository.UpdateAsync(addressEntity, cancellationToken).Result;

                return _mapper.Map<AddressDto>(updatedAddress);

            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error occurred while handling UpdateAddressCommand");
                throw;
            }

        }
    }
}

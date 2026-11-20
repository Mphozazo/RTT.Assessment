using AutoMapper;
using MediatR;
using RTT.Assessment.Application.Contracts.Persistence;
using RTT.Assessment.Application.Exceptions;
using RTT.Assessment.Application.Features.Address.Queries;
using System;
using System.Collections.Generic;
using System.Text;

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
            var validator = new UpdateAddressCommandValidator();
            var validationResult = validator.Validate(request);
            if (!validationResult.IsValid)
                throw new BadRequestException("Address validation failed", validationResult);

            var addressEntity = _mapper.Map<Domain.Address>(request);

            var updatedAddress = _addressRepository.UpdateAsync(addressEntity, cancellationToken).Result;

            return _mapper.Map<AddressDto>(updatedAddress);

        }
    }
}

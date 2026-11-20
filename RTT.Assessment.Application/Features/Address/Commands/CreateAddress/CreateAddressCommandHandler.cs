using AutoMapper;
using MediatR;
using RTT.Assessment.Application.Contracts.Persistence;
using RTT.Assessment.Application.Exceptions;
using RTT.Assessment.Application.Features.Address.Commands.Shared;
using RTT.Assessment.Application.Features.Address.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace RTT.Assessment.Application.Features.Address.Commands.CreateAddress
{
    public class CreateAddressCommandHandler : IRequestHandler<CreateAddressCommand, AddressDto>
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;
        public CreateAddressCommandHandler(IAddressRepository addressRepository, IMapper mapper)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
        }
        public async Task<AddressDto> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateBaseAddressCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                throw new BadRequestException("Address validation failed", validationResult);

            var addressEntity = _mapper.Map<Domain.Address>(request);
            var createdAddress = await _addressRepository.AddAsync(addressEntity, cancellationToken);
            return _mapper.Map<AddressDto>(createdAddress);
        }
    }
}

using MediatR;
using RTT.Assessment.Application.Features.Address.Commands.Shared;
using RTT.Assessment.Application.Features.Address.Queries;
using RTT.Assessment.Domain.Enums;

namespace RTT.Assessment.Application.Features.Address.Commands.CreateAddress;

public class CreateAddressCommand : BaseAddressCommand, IRequest<AddressDto> { }
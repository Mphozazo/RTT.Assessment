using MediatR;
using RTT.Assessment.Application.Features.Address.Commands.Shared;
using RTT.Assessment.Application.Features.Address.Queries;

namespace RTT.Assessment.Application.Features.Address.Commands.UpdateAddress;

public class UpdateAddressCommand : BaseAddressCommand ,  IRequest<AddressDto> { }